REM @echo off
@setlocal
@cd /d %~dp0

del /F /S /Q WcfLoadTest.WcfServiceClient
copy lib\*.* WcfLoadTest.WcfServiceClient
copy ..\WcfLoadTest.WcfServiceClient\bin\Release\*.* WcfLoadTest.WcfServiceClient
bin\proxygen.exe WcfLoadTest.WcfServiceClient\WcfLoadTest.WcfServiceClient.dll -wd WcfLoadTest.WcfServiceClient
cd WcfLoadTest.WcfServiceClient

set path="C:\Program Files\Java\jdk1.7.0_80\bin";%path%
set path="C:\Windows\Microsoft.NET\Framework64\v4.0.30319";%path%

call build.cmd
cd ..

echo compiling usage
javac -d WcfLoadTest.WcfServiceClient\ -cp WcfLoadTest.WcfServiceClient\jni4net.j-0.8.8.0.jar;WcfLoadTest.WcfServiceClient\WcfLoadTest.WcfServiceClient.j4n.jar WcfLoadTest.WcfServiceClient.Sample.java

pause

run.cmd