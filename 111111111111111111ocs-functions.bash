
  kver_initrd="$(LC_ALL=C find $mnt_pnt/boot/ -name "vmlinuz*" -print 2>/dev/null | sort -r -V | head -n 1 | xargs basename | sed -r -e "s/^vmlinuz-//g")"
  # Get the file name for initramfs
  initrd_2_be_updated="$(LC_ALL=C find $mnt_pnt/boot/ -name "init*${kver_initrd}*" -print 2>/dev/null | grep -v kdum)"
  # Decide it's update-initramfs or dracut
  mkinitrd_run_sh="$(mktemp $mnt_pnt/grub2-sh-XXXXXX)"
  if [ -e "$mnt_pnt/usr/bin/dracut" ]; then
    initrd_tool="dracut"
  elif [ -e "$mnt_pnt/usr/sbin/update-initramfs" ]; then
    initrd_tool="update-initramfs"
  elif [ -e "$mnt_pnt/usr/sbin/make-initrd" ]; then
    initrd_tool="make-initrd"
  fi
  case "$initrd_tool" in
    # initrd_tool for ALT Education 9.2 x86_64 from 05/20/2021
    "make-initrd")
      mkinitrd_cmd="make-initrd --kernel=$(ls $mnt_pnt/lib/modules | grep alt)" ;;
    "update-initramfs")
      mkinitrd_cmd="update-initramfs -u -k all" ;;
    "dracut")
      # Here we assign tmpdir as /tmp, since by default it's /var/tmp, but in chroot the /var might be in another partition.
      mkinitrd_cmd="dracut --tmpdir /tmp -f ${initrd_2_be_updated#$mnt_pnt} $kver_initrd" ;;
    *)
	
echo "$(LC_ALL=C find $mnt_pnt/boot/ -name "init*${"$(LC_ALL=C find $mnt_pnt/boot/ -name "vmlinuz*" -print 2>/dev/null | sort -r -V | head -n 1 | xargs basename | sed -r -e "s/^vmlinuz-//g")"}*" -print 2>/dev/null | grep -v kdum)"