@echo off
cd /D "F:\Sharp Dynamics\Kilometros for Windows\Kilometros WinUSB Driver Package"

echo == Generating new *.cat ==
@del .\kmsdevice.cat
"C:\Program Files (x86)\Windows Kits\8.1\bin\x86\inf2cat.exe" /driver:. /os:8_X64,8_X86,Server8_X64,Server2008R2_X64,7_X64,7_X86,Server2008_X64,Server2008_X86,Vista_X64,Vista_X86
echo ""
echo ""

echo == Signing Drivers ==
"C:\Program Files (x86)\Windows Kits\8.0\bin\x64\signtool.exe" sign /s KmsMxCertStore /r "KMS Mexico" /n "KMS Protype Drivers" /t http://timestamp.verisign.com/scripts/timestamp.dll .\kmsdevice.cat
echo ""
echo ""
echo ALL DONE
pause