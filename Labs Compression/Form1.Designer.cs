
namespace Labs_Compression
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSource = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.textSource = new System.Windows.Forms.TextBox();
            this.textResult = new System.Windows.Forms.TextBox();
            this.groupAlgorithm = new System.Windows.Forms.GroupBox();
            this.radioHUFFMAN = new System.Windows.Forms.RadioButton();
            this.radioLZW = new System.Windows.Forms.RadioButton();
            this.radioRLE = new System.Windows.Forms.RadioButton();
            this.buttonCompress = new System.Windows.Forms.Button();
            this.labelCompressTime = new System.Windows.Forms.Label();
            this.labelDecompressTime = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.groupAlgorithm.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSource
            // 
            this.labelSource.Location = new System.Drawing.Point(12, 9);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(274, 13);
            this.labelSource.TabIndex = 0;
            this.labelSource.Text = "Исходный текст";
            this.labelSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelResult
            // 
            this.labelResult.Location = new System.Drawing.Point(292, 9);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(274, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "Текст после сжатия";
            this.labelResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textSource
            // 
            this.textSource.Location = new System.Drawing.Point(12, 25);
            this.textSource.Multiline = true;
            this.textSource.Name = "textSource";
            this.textSource.Size = new System.Drawing.Size(274, 152);
            this.textSource.TabIndex = 2;
            // 
            // textResult
            // 
            this.textResult.Location = new System.Drawing.Point(292, 25);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(274, 152);
            this.textResult.TabIndex = 3;
            // 
            // groupAlgorithm
            // 
            this.groupAlgorithm.Controls.Add(this.radioHUFFMAN);
            this.groupAlgorithm.Controls.Add(this.radioLZW);
            this.groupAlgorithm.Controls.Add(this.radioRLE);
            this.groupAlgorithm.Location = new System.Drawing.Point(12, 183);
            this.groupAlgorithm.Name = "groupAlgorithm";
            this.groupAlgorithm.Size = new System.Drawing.Size(134, 100);
            this.groupAlgorithm.TabIndex = 4;
            this.groupAlgorithm.TabStop = false;
            this.groupAlgorithm.Text = "Алгоритм сжатия";
            // 
            // radioHUFFMAN
            // 
            this.radioHUFFMAN.AutoSize = true;
            this.radioHUFFMAN.Location = new System.Drawing.Point(6, 65);
            this.radioHUFFMAN.Name = "radioHUFFMAN";
            this.radioHUFFMAN.Size = new System.Drawing.Size(77, 17);
            this.radioHUFFMAN.TabIndex = 5;
            this.radioHUFFMAN.Text = "HUFFMAN";
            this.radioHUFFMAN.UseVisualStyleBackColor = true;
            // 
            // radioLZW
            // 
            this.radioLZW.AutoSize = true;
            this.radioLZW.Location = new System.Drawing.Point(6, 42);
            this.radioLZW.Name = "radioLZW";
            this.radioLZW.Size = new System.Drawing.Size(49, 17);
            this.radioLZW.TabIndex = 5;
            this.radioLZW.Text = "LZW";
            this.radioLZW.UseVisualStyleBackColor = true;
            // 
            // radioRLE
            // 
            this.radioRLE.AutoSize = true;
            this.radioRLE.Checked = true;
            this.radioRLE.Location = new System.Drawing.Point(6, 19);
            this.radioRLE.Name = "radioRLE";
            this.radioRLE.Size = new System.Drawing.Size(46, 17);
            this.radioRLE.TabIndex = 0;
            this.radioRLE.TabStop = true;
            this.radioRLE.Text = "RLE";
            this.radioRLE.UseVisualStyleBackColor = true;
            // 
            // buttonCompress
            // 
            this.buttonCompress.Location = new System.Drawing.Point(152, 188);
            this.buttonCompress.Name = "buttonCompress";
            this.buttonCompress.Size = new System.Drawing.Size(134, 95);
            this.buttonCompress.TabIndex = 5;
            this.buttonCompress.Text = "Сжать";
            this.buttonCompress.UseVisualStyleBackColor = true;
            this.buttonCompress.Click += new System.EventHandler(this.buttonCompress_Click);
            // 
            // labelCompressTime
            // 
            this.labelCompressTime.Location = new System.Drawing.Point(292, 188);
            this.labelCompressTime.Name = "labelCompressTime";
            this.labelCompressTime.Size = new System.Drawing.Size(274, 13);
            this.labelCompressTime.TabIndex = 6;
            this.labelCompressTime.Text = "Время компрессии:";
            this.labelCompressTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDecompressTime
            // 
            this.labelDecompressTime.Location = new System.Drawing.Point(292, 207);
            this.labelDecompressTime.Name = "labelDecompressTime";
            this.labelDecompressTime.Size = new System.Drawing.Size(274, 13);
            this.labelDecompressTime.TabIndex = 7;
            this.labelDecompressTime.Text = "Время декомпрессии:";
            this.labelDecompressTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelCopyright.Location = new System.Drawing.Point(292, 270);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(274, 13);
            this.labelCopyright.TabIndex = 8;
            this.labelCopyright.Text = "Copyright ITSS-18 Maks Grishin";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 293);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelDecompressTime);
            this.Controls.Add(this.labelCompressTime);
            this.Controls.Add(this.buttonCompress);
            this.Controls.Add(this.groupAlgorithm);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textSource);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.labelSource);
            this.Name = "MainForm";
            this.Text = "Compression Assistant";
            this.groupAlgorithm.ResumeLayout(false);
            this.groupAlgorithm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TextBox textSource;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.GroupBox groupAlgorithm;
        private System.Windows.Forms.RadioButton radioHUFFMAN;
        private System.Windows.Forms.RadioButton radioLZW;
        private System.Windows.Forms.RadioButton radioRLE;
        private System.Windows.Forms.Button buttonCompress;
        private System.Windows.Forms.Label labelCompressTime;
        private System.Windows.Forms.Label labelDecompressTime;
        private System.Windows.Forms.Label labelCopyright;
    }
}

