@echo off
cd /D "E:\KMS Invent\KMS Desktop\Kms WinUSB Driver Package"

echo == Generating new *.cat ==
@del .\kmsdevice.cat
"C:\Program Files (x86)\Windows Kits\8.1\bin\x86\inf2cat.exe" /driver:. /os:6_3_X86,6_3_X64,Server6_3_X64,8_X64,8_X86,Server8_x64,Server2008R2_X64,Server2008R2_IA64,7_X64,7_X86,Server2008_X64,Server2008_IA64,Server2008_X86,Vista_X64,Vista_X86,Server2003_X64,Server2003_IA64,Server2003_X86,XP_X64,XP_X86

echo == Signing Drivers ==
"C:\Program Files (x86)\Windows Kits\8.0\bin\x64\signtool.exe" sign /s "KMS Invent" /n "KMS Invent Software" /t http://timestamp.verisign.com/scripts/timestamp.dll /d "KMS Invent USB Device Sync Cable Driver" .\kmsdevice.cat
REM "C:\Program Files (x86)\Windows Kits\8.0\bin\x64\signtool.exe" sign /s KmsInventCertStore /n "KMS Invent Software Certificate" /t http://timestamp.verisign.com/scripts/timestamp.dll /d "KMS Invent USB Device Sync Cable Driver" .\kmsdevice.cat

echo ALL DONE
pause