REM @echo off
@setlocal
@cd /d %~dp0

del /F /S /Q WcfLoadTest.JMeterAction
copy lib\*.* WcfLoadTest.JMeterAction
copy ..\WcfLoadTest.JMeterAction\bin\Release\*.* WcfLoadTest.JMeterAction
bin\proxygen.exe WcfLoadTest.JMeterAction\WcfLoadTest.JMeterAction.dll -wd WcfLoadTest.JMeterAction -dp "WcfLoadTest.JMeterAction\JMeter.Data.dll"
cd WcfLoadTest.JMeterAction

set path="C:\Program Files\Java\jdk1.7.0_80\bin";%path%
set path="C:\Windows\Microsoft.NET\Framework64\v4.0.30319";%path%

call build.cmd
cd ..

echo compiling usage
javac -d WcfLoadTest.JMeterAction\ -cp WcfLoadTest.JMeterAction\jni4net.j-0.8.8.0.jar;WcfLoadTest.JMeterAction\WcfLoadTest.JMeterAction.j4n.jar WcfLoadTest.JMeterAction.Sample.java

pause

run.cmd