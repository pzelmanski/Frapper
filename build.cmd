
@echo off
cls

.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

@REM .paket\paket.exe restore
@REM if errorlevel 1 (
@REM   exit /b %errorlevel%
@REM )

dotnet restore
fake run build.fsx 