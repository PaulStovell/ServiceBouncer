ECHO OFF
cls
.paket\paket.bootstrapper.exe --run restore
packages\FAKE\tools\FAKE.exe build.fsx