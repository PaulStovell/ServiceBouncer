@echo off
setlocal
color 07
pushd %~dp0
cd .fake-script
cls

ECHO ----------------------------
ECHO Update Paket
ECHO ----------------------------
dotnet tool update paket
if errorlevel 1 (
  GOTO :end
)

ECHO ----------------------------
ECHO Update Fake
ECHO ----------------------------
dotnet tool update fake-cli
if errorlevel 1 (
  GOTO :end
)

ECHO ----------------------------
ECHO Paket Update
ECHO ----------------------------
dotnet paket update

:end
exit /b %errorlevel%
