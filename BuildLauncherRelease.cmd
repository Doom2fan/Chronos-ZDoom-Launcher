@ECHO OFF
RD .\LauncherBuild /S /Q
MD .\LauncherBuild

SET msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
CALL %msBuildDir%\msbuild.exe Launcher.sln /p:Configuration=Debug /p:Platform="x86"
SET msBuildDir=

XCOPY .\Project\bin\x86\Debug\Launcher.exe .\LauncherBuild\
XCOPY .\Project\bin\x86\Debug\Launcher.pdb .\LauncherBuild\
XCOPY .\Project\bin\x86\Debug\ICSharpCode.SharpZipLib.dll .\LauncherBuild\

PAUSE

CLS
ECHO Launcher compiled.
ECHO Files copied to LauncherBuild folder.

PAUSE