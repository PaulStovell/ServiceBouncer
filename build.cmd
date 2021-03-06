@echo off
setlocal
set PAKET_SKIP_RESTORE_TARGETS=true
color 07
cls

ECHO ----------------------------
ECHO Restore Tools
ECHO ----------------------------
dotnet tool restore
if errorlevel 1 (
  GOTO :end
)

ECHO ----------------------------
ECHO Restore
ECHO ----------------------------
dotnet paket restore
if errorlevel 1 (
  GOTO :end
)

ECHO ----------------------------
ECHO Run Fake
ECHO ----------------------------
dotnet fake run build.fsx

:end
exit /b %errorlevel%
