using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs_Compression
{
    public partial class MainForm : Form
    {
        Timer timer = new Timer();
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCompress_Click(object sender, EventArgs e)
        {
            if (radioRLE.Checked)
            {

                StringBuilder compressed = new StringBuilder();
                StringBuilder number = new StringBuilder();
                int count = 0; char currentSybmol = textSource.Text[0];

                timer.Start();
                foreach (char symbol in textSource.Text)
                {
                    if (symbol == currentSybmol) { count++; }
                    else { compressed.Append(count.ToString() + currentSybmol); currentSybmol = symbol; count = 1; }
                }
                compressed.Append(count.ToString() + currentSybmol); textResult.Text = compressed.ToString(); compressed.Clear();
                labelCompressTime.Text = "Время компрессии: " + timer.Stop() + "мс";

                timer.Start();
                foreach (char symbol in textResult.Text)
                {
                    if (char.IsDigit(symbol)) { number.Append(symbol); }
                    else { for (int i = 0; i < int.Parse(number.ToString()); i++) { compressed.Append(symbol); } number.Clear(); }
                }
                textSource.Text = compressed.ToString(); compressed.Clear();
                labelDecompressTime.Text = "Время декомпрессии: " + timer.Stop() + "мс";
            }
            if (radioLZW.Checked)
            {
                string w = string.Empty; var enc = Encoding.GetEncoding(1251);
                List<int> compressed = new List<int>();
                Dictionary<string, int> dictionaryCompress = new Dictionary<string, int>();
                Dictionary<int, string> dictionaryDecompress = new Dictionary<int, string>();

                timer.Start();
                for (int i = 0; i < 256; i++) { dictionaryCompress.Add(enc.GetString(new[] { (byte)i }), i); }

                foreach (char c in textSource.Text)
                {
                    string wc = w + c;

                    if (dictionaryCompress.ContainsKey(wc)) { w = wc; }
                    else { compressed.Add(dictionaryCompress[w]); dictionaryCompress.Add(wc, dictionaryCompress.Count); w = c.ToString(); }
                }

                if (!string.IsNullOrEmpty(w)) { compressed.Add(dictionaryCompress[w]); }

                textResult.Text = string.Join(", ", compressed); labelCompressTime.Text = "Время компрессии: " + timer.Stop() + "мс";

                timer.Start();
                for (int i = 0; i < 256; i++) { dictionaryDecompress.Add(i, enc.GetString(new[] { (byte)i })); }

                compressed = textResult.Text.Split(',').Select(Int32.Parse).ToList();

                w = dictionaryDecompress[compressed[0]];
                compressed.RemoveAt(0);
                StringBuilder decompressed = new StringBuilder(w);

                foreach (int k in compressed)
                {
                    string entry = null;

                    if (dictionaryDecompress.ContainsKey(k)) { entry = dictionaryDecompress[k]; }
                    else if (k == dictionaryDecompress.Count) { entry = w + w[0]; }

                    decompressed.Append(entry); dictionaryDecompress.Add(dictionaryDecompress.Count, w + entry[0]); w = entry;
                }
                textSource.Text = decompressed.ToString(); labelDecompressTime.Text = "Время декомпрессии: " + timer.Stop() + "мс";
            }
            if (radioHUFFMAN.Checked)
            {
                StringBuilder compressed = new StringBuilder();
                HuffmanTree huffmanTree = new HuffmanTree(); huffmanTree.Build(textSource.Text);
                BitArray encoded = huffmanTree.Encode(textSource.Text);

                foreach (bool bit in encoded) { compressed.Append((bit ? 1 : 0)); }

                timer.Start(); textResult.Text = compressed.ToString(); labelCompressTime.Text = "Время компрессии: " + timer.Stop() + "мс";
                timer.Start(); textSource.Text = huffmanTree.Decode(encoded); labelDecompressTime.Text = "Время декомпрессии: " + timer.Stop() + "мс";
            }
        }
    }

    public class Node
    {
        public char Symbol { get; set; }
        public int Frequency { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }
        public List<bool> Traverse(char symbol, List<bool> data)
        {
            if (Right == null && Left == null) { if (symbol.Equals(this.Symbol)) { return data; } else { return null; } }
            else
            {
                List<bool> left = null; List<bool> right = null;

                if (Left != null) { List<bool> leftPath = new List<bool>(); leftPath.AddRange(data); leftPath.Add(false); left = Left.Traverse(symbol, leftPath); }
                if (Right != null) { List<bool> rightPath = new List<bool>(); rightPath.AddRange(data); rightPath.Add(true); right = Right.Traverse(symbol, rightPath); }
                if (left != null) { return left; } else { return right; }
            }
        }
    }

    public class HuffmanTree
    {
        private List<Node> nodes = new List<Node>();
        public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

        public Node Root { get; set; }

        public void Build(string source)
        {
            for (int i = 0; i < source.Length; i++) { if (!Frequencies.ContainsKey(source[i])) { Frequencies.Add(source[i], 0); } Frequencies[source[i]]++; }

            foreach (KeyValuePair<char, int> symbol in Frequencies) { nodes.Add(new Node() { Symbol = symbol.Key, Frequency = symbol.Value }); }

            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.Frequency).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();
                    Node parent = new Node() { Symbol = '*', Frequency = taken[0].Frequency + taken[1].Frequency, Left = taken[0], Right = taken[1] };
                    nodes.Remove(taken[0]); nodes.Remove(taken[1]); nodes.Add(parent);
                }
                this.Root = nodes.FirstOrDefault();
            }
        }

        public BitArray Encode(string source)
        {
            List<bool> encodedSource = new List<bool>();

            for (int i = 0; i < source.Length; i++)
            {
                List<bool> encodedSymbol = this.Root.Traverse(source[i], new List<bool>());
                encodedSource.AddRange(encodedSymbol);
            }
            BitArray bits = new BitArray(encodedSource.ToArray()); return bits;
        }

        public string Decode(BitArray bits)
        {
            Node current = this.Root; string decoded = "";

            foreach (bool bit in bits)
            {
                if (bit && current.Right != null) { current = current.Right; }
                else if (current.Left != null) { current = current.Left; }
                if (IsLeaf(current)) { decoded += current.Symbol; current = this.Root; }
            }
            return decoded;
        }

        public bool IsLeaf(Node node) { return (node.Left == null && node.Right == null); }
    }

    public class Timer
    {
        DateTime timeStart, timeEnd = new DateTime();
        TimeSpan timeDifference = new TimeSpan();

        public void Start() { timeStart = DateTime.Now; }
        public string Stop() { timeEnd = DateTime.Now; timeDifference = timeEnd - timeStart; return timeDifference.TotalMilliseconds.ToString(); }
    }
}