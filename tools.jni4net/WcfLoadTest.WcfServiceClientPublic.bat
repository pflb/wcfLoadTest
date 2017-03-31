REM @echo off
@setlocal
@cd /d %~dp0

del /F /S /Q WcfLoadTest.WcfServiceClientPublic
copy lib\*.* WcfLoadTest.WcfServiceClientPublic
copy ..\WcfLoadTest.WcfServiceClientPublic\bin\Release\*.* WcfLoadTest.WcfServiceClientPublic
bin\proxygen.exe WcfLoadTest.WcfServiceClientPublic\WcfLoadTest.WcfServiceClientPublic.dll -wd WcfLoadTest.WcfServiceClientPublic
cd WcfLoadTest.WcfServiceClientPublic

set path="C:\Program Files\Java\jdk1.7.0_80\bin";%path%
set path="C:\Windows\Microsoft.NET\Framework64\v4.0.30319";%path%

call build.cmd
cd ..

echo compiling usage
javac -d WcfLoadTest.WcfServiceClientPublic\ -cp WcfLoadTest.WcfServiceClientPublic\jni4net.j-0.8.8.0.jar;WcfLoadTest.WcfServiceClientPublic\WcfLoadTest.WcfServiceClientPublic.j4n.jar WcfLoadTest.WcfServiceClientPublic.Sample.java

pause

run.cmd