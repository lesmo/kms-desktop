cd /d "F:\Sharp Dynamics\Kilometros for Windows\Kilometros Desktop" &msbuild "KMS Desktop.csproj" /t:sdvViewer /p:configuration="Debug" /p:platform=Any CPU
exit %errorlevel% 