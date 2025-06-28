@echo off
title HotkeyPopUp - Fresh Build Script

echo.
echo [🔍] Terminating any running HotkeyPopUp.exe...
taskkill /F /IM HotkeyPopUp.exe >nul 2>&1

:: Timestamp for unique publish dir
for /f %%i in ('wmic os get localdatetime ^| find "."') do set DTS=%%i
set DTS=%DTS:~0,4%-%DTS:~4,2%-%DTS:~6,2%_%DTS:~8,2%-%DTS:~10,2%-%DTS:~12,2%
set PUBDIR=bin\Release\net6.0-windows\win-x64\publish\%DTS%

echo.
echo [🚀] Publishing to %PUBDIR% ...
dotnet publish -c Release -r win-x64 ^
    -p:PublishSingleFile=true ^
    -p:SelfContained=true ^
    -o "%PUBDIR%"

if %ERRORLEVEL%==0 (
    echo.
    echo [✅] Build succeeded!
    echo     %PUBDIR%\HotkeyPopUp.exe
) else (
    echo.
    echo [❌] Build FAILED!
)

echo.
pause
