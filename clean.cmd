@echo off

msbuild.exe /p:Configuration="%config%" /p:Platform="Any CPU" ^
  /verbosity:minimal ^
  /nologo ^
  /fl ^
  /flp:LogFile=clean.log;Verbosity=detailed ^
  /t:clean ^
  lezen.sln

