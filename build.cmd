echo off
cls

ECHO ----------------------------
ECHO Get Build Tools
ECHO ----------------------------
.paket\paket.exe restore -g BuildTools
@if %errorlevel% neq 0 exit /b %errorlevel%

ECHO ----------------------------
ECHO Restore
ECHO ----------------------------
dotnet restore
@if %errorlevel% neq 0 exit /b %errorlevel%

ECHO ----------------------------
ECHO Build
ECHO ----------------------------
dotnet fake run build.fsx