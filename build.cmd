@echo off
set config=%1

if "%config%" == "" (
   set config=Debug
)

msbuild.exe /p:Configuration="%config%" /p:Platform="Any CPU" ^
  /maxcpucount ^
  /verbosity:minimal ^
  /nologo ^
  /fl ^
  /flp:LogFile=build.log;Verbosity=detailed ^
  build\build.proj
  
  
  