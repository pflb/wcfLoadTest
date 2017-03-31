@echo off
if not exist target mkdir target
if not exist target\classes mkdir target\classes


echo compile classes
javac -nowarn -d target\classes -sourcepath jvm -cp "d:\project\_wcfloadtest\tools.jni4net\lib\jni4net.j-0.8.8.0.jar"; "jvm\wcfloadtest/wcfserviceclient\ConfigLoader.java" "jvm\wcfloadtest/wcfserviceclient\ServiceBasicHttpClient.java" "jvm\wcfloadtest/wcfserviceclient\ServiceNetTcpClient.java" "jvm\wcfloadtest/wcfserviceclient\ServiceSoap11Client.java" "jvm\wcfloadtest/wcfserviceclient\ServiceSoapMsBin1Client.java" 
IF %ERRORLEVEL% NEQ 0 goto end


echo WcfLoadTest.WcfServiceClient.j4n.jar 
jar cvf WcfLoadTest.WcfServiceClient.j4n.jar  -C target\classes "wcfloadtest\wcfserviceclient\ConfigLoader.class"  -C target\classes "wcfloadtest\wcfserviceclient\ServiceBasicHttpClient.class"  -C target\classes "wcfloadtest\wcfserviceclient\ServiceNetTcpClient.class"  -C target\classes "wcfloadtest\wcfserviceclient\ServiceSoap11Client.class"  -C target\classes "wcfloadtest\wcfserviceclient\ServiceSoapMsBin1Client.class"  > nul 
IF %ERRORLEVEL% NEQ 0 goto end


echo WcfLoadTest.WcfServiceClient.j4n.dll 
csc /nologo /warn:0 /t:library /out:WcfLoadTest.WcfServiceClient.j4n.dll /recurse:clr\*.cs  /reference:"D:\project\_wcfLoadTest\tools.jni4net\WcfLoadTest.WcfServiceClient\WcfLoadTest.WcfServiceClient.dll" /reference:"D:\project\_wcfLoadTest\tools.jni4net\lib\jni4net.n-0.8.8.0.dll"
IF %ERRORLEVEL% NEQ 0 goto end


:end
