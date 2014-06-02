#define KmsAppInstallerName "KMS App"
#define KmsAppVersion "1.1.0.0"
#define KmsAppPublisher "KMS Invent S.A.P.I. de C.V."
#define KmsAppURL "http://www.kms.me"
#define KmsAppExeName "KMS.exe"
#define KmsDriverInstallerExeName "KMS Driver Installer.exe"
#define KmsAppMutex ".@?jH?%C??T*?G?"

[Setup]
AppId={{F9E0A2BD-1201-4775-8523-F98051B7C076}
AppName={cm:KmsAppName}
AppVersion={#KmsAppVersion}
AppVerName=KMS v{#KmsAppVersion}
AppPublisher={#KmsAppPublisher}
AppPublisherURL={#KmsAppURL}
AppSupportURL={#KmsAppURL}
AppUpdatesURL={#KmsAppURL}
DefaultDirName={userpf}\{#KmsAppInstallerName}
DefaultGroupName={cm:KmsAppName}
DisableProgramGroupPage=yes
OutputBaseFilename={#KmsAppInstallerName} v{#KmsAppVersion} Setup
Compression=lzma2/ultra64
SolidCompression=yes
DisableReadyPage=True
DisableReadyMemo=True
TimeStampsInUTC=True
MinVersion=0,6.0
AllowUNCPath=False
PrivilegesRequired=lowest
AppMutex={#KmsAppMutex}
WizardImageFile=BannerLeft.bmp
WizardSmallImageFile=MiniTop.bmp
WizardImageBackColor=clWhite
InternalCompressLevel=ultra
ShowLanguageDialog=auto

[Languages]
Name: "english"; MessagesFile: "KMS Setup.English.isl"
Name: "spanish"; MessagesFile: "KMS Setup.Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"

[Files]
Source: "..\Kms Desktop Windows Driver Install\bin\Release\*"; DestDir: "{tmp}"; Flags: dontcopy recursesubdirs
Source: "..\KMS Desktop\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion createallsubdirs recursesubdirs

[Icons]
Name: "{group}\{cm:KmsAppName}"; Filename: "{app}\{#KmsAppExeName}"
Name: "{userdesktop}\{cm:KmsAppName}"; Filename: "{app}\{#KmsAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#KmsAppExeName}"; Flags: nowait postinstall skipifsilent; Description: "{cm:LaunchProgram, KMS}"

[Code]
function PrepareToInstall(var NeedsRestart: Boolean): String;
var
  ResultCode: Integer;
var
  SilentFlag: String;
begin
  if Pos('/SKIPDRIVER', Uppercase(GetCmdTail())) > 0 then
  begin
    Result := '';
  end
  else begin
    // Extraer todos los archivos requeridos para la instalación del Driver.
    ExtractTemporaryFiles('{tmp}\*.*');
    ExtractTemporaryFiles('{tmp}\Certificates\*.cer');
    ExtractTemporaryFiles('{tmp}\Driver\*.*');
    ExtractTemporaryFiles('{tmp}\Driver\amd64\*.*');
    ExtractTemporaryFiles('{tmp}\Driver\x86\*.*');
    ExtractTemporaryFiles('{tmp}\Driver\ia64\*.*');
    ExtractTemporaryFiles('{tmp}\Driver\meta\*.*');

    // Determinar si se solicitó ejecutar el instalador del Driver en modo interactivo.
    if not Pos('/INTERACTIVEDRIVERINSTALL', Uppercase(GetCmdTail())) > 0 then
    begin
      SilentFlag := '-Silent';
    end;
    
    // Ejecutar el instalador.
    ResultCode := -999;
    Exec(
      ExpandConstant('{tmp}\{#KmsDriverInstallerExeName}'),
      SilentFlag,
      '',
      SW_SHOW,
      ewWaitUntilTerminated,
      ResultCode
    )
    
    // Revisar el resultado de la instalación del Driver.
    if ( ResultCode <> 0 ) then
    begin
      Result := FmtMessage(CustomMessage('InstallKmsDriverFail'), [Format('%.x', [ResultCode])]);
    end
    else begin
      Result := '';
    end;
  end;
end;
