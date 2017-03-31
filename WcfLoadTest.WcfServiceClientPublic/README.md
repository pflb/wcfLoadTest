# Лог сборки обёртки

Во время создания обёртки для public-классов, созданных с помощью генерации кода **svcutil** для каждого клиента генерируются ошибки.

Например, ошибки для файла

	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs


<table>
 <tr>
  <td>error CS0102</td>
  <td>Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Closed"</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closed"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closing"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td>error CS0102</td>
  <td>Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Closing"</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closing"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Faulted"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td>error CS0102</td>
  <td>Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Faulted"</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Faulted"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Opened"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td>error CS0102</td>
  <td>Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Opened"</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Opened"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td rowspan="2">error CS0065</td>
  <td>"WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.UnknownMessageReceived"</td>
 </tr>
 <tr>
  <td>свойство события должно иметь и функцию доступа add, и remove</td>
 </tr>
 <tr>
  <td>error CS0102</td>
  <td>Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "UnknownMessageReceived"</td>
 </tr>
</table>

Полный лог создания обёртки:

	D:\project\_wcfLoadTest\tools.jni4net>copy lib\*.* WcfLoadTest.WcfServiceClientPublic 
	
	lib\jni4net-MIT.txt
	lib\jni4net.j-0.8.8.0.jar
	lib\jni4net.n-0.8.8.0.dll
	lib\jni4net.n.w32.v20-0.8.8.0.dll
	lib\jni4net.n.w32.v40-0.8.8.0.dll
	lib\jni4net.n.w64.v20-0.8.8.0.dll
	lib\jni4net.n.w64.v40-0.8.8.0.dll
	
	Скопировано файлов:         7.
	
	D:\project\_wcfLoadTest\tools.jni4net>copy ..\WcfLoadTest.WcfServiceClientPublic\bin\Release\*.* WcfLoadTest.WcfServiceClientPublic 
	
	..\WcfLoadTest.WcfServiceClientPublic\bin\Release\WcfLoadTest.WcfServiceClientPublic.dll
	..\WcfLoadTest.WcfServiceClientPublic\bin\Release\WcfLoadTest.WcfServiceClientPublic.dll.config
	
	Скопировано файлов:         2.
	
	D:\project\_wcfLoadTest\tools.jni4net>bin\proxygen.exe WcfLoadTest.WcfServiceClientPublic\WcfLoadTest.WcfServiceClientPublic.dll -wd WcfLoadTest.WcfServiceClientPublic 
	jni4net.proxygen - Copyright (C) 2009 Pavel Savara - licensed under GPLv3
	
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoapmsbin1.iservicesoapmsbin1
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoapmsbin1.iservicesoapmsbin1channel
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoapmsbin1.servicesoapmsbin1client
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoap11.iservicesoap11
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoap11.iservicesoap11channel
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencesoap11.servicesoap11client
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencenettcp.iservicenettcp
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencenettcp.iservicenettcpchannel
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencenettcp.servicenettcpclient
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencebasichttp.iservicebasichttp
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencebasichttp.iservicebasichttpchannel
	will generate JVM wcfloadtest.wcfserviceclientpublic.servicereferencebasichttp.servicebasichttpclient
	proxygen done
	
	D:\project\_wcfLoadTest\tools.jni4net>cd WcfLoadTest.WcfServiceClientPublic 
	
	D:\project\_wcfLoadTest\tools.jni4net\WcfLoadTest.WcfServiceClientPublic>set path="C:\Program Files\Java\jdk1.7.0_80\bin";D:\app\oracleUser\product\12.1.0\dbhome_2\bin;D:\app\oracleUser\product\12.1.0\dbhome_1\bin;C:\ProgramData\Oracle\Java\javapath;C:\Program Files (x86)\NVIDIA Corporation\PhysX\Common;C:\Program Files (x86)\Intel\iCLS Client\;C:\Program Files\Intel\iCLS Client\;C:\Windows\system32;C:\Windows;C:\Windows\System32\Wbem;C:\Windows\System32\WindowsPowerShell\v1.0\;C:\Program Files\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files\Intel\Intel(R) Management Engine Components\IPT;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\IPT;C:\Program Files (x86)\Intel\OpenCL SDK\3.0\bin\x86;C:\Program Files (x86)\Intel\OpenCL SDK\3.0\bin\x64;C:\Program Files\Intel\WiFi\bin\;C:\Program Files\Common Files\Intel\WirelessCommon\;C:\Program Files\Calibre2\;C:\Program Files (x86)\HP\LoadRunner\strawberry-perl\perl\bin;C:\Program Files\Git\cmd;C:\Program Files\OpenVPN\bin;C:\Program Files (x86)\GNU\GnuPG\pub;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\DTS\Binn\;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\;C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies\;C:\Program Files (x86)\Microsoft SQL Server\100\DTS\Binn\;d:\Users\user\.dnx\bin;C:\Program Files\Microsoft DNX\Dnvm\;C:\Program Files (x86)\Windows Kits\8.1\Windows Performance Toolkit\;C:\Program Files\Microsoft SQL Server\120\Tools\Binn\;C:\Program Files\Microsoft SQL Server\130\Tools\Binn\;C:\Program Files (x86)\Skype\Phone\;d:\Users\user\.dnx\bin;d:\Users\user\Anaconda2;d:\Users\user\Anaconda2\Scripts;d:\Users\user\Anaconda2\Library\bin;C:\Program Files (x86)\apache-maven-3.3.9\bin 
	
	D:\project\_wcfLoadTest\tools.jni4net\WcfLoadTest.WcfServiceClientPublic>set path="C:\Windows\Microsoft.NET\Framework64\v4.0.30319";"C:\Program Files\Java\jdk1.7.0_80\bin";D:\app\oracleUser\product\12.1.0\dbhome_2\bin;D:\app\oracleUser\product\12.1.0\dbhome_1\bin;C:\ProgramData\Oracle\Java\javapath;C:\Program Files (x86)\NVIDIA Corporation\PhysX\Common;C:\Program Files (x86)\Intel\iCLS Client\;C:\Program Files\Intel\iCLS Client\;C:\Windows\system32;C:\Windows;C:\Windows\System32\Wbem;C:\Windows\System32\WindowsPowerShell\v1.0\;C:\Program Files\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files\Intel\Intel(R) Management Engine Components\IPT;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\DAL;C:\Program Files (x86)\Intel\Intel(R) Management Engine Components\IPT;C:\Program Files (x86)\Intel\OpenCL SDK\3.0\bin\x86;C:\Program Files (x86)\Intel\OpenCL SDK\3.0\bin\x64;C:\Program Files\Intel\WiFi\bin\;C:\Program Files\Common Files\Intel\WirelessCommon\;C:\Program Files\Calibre2\;C:\Program Files (x86)\HP\LoadRunner\strawberry-perl\perl\bin;C:\Program Files\Git\cmd;C:\Program Files\OpenVPN\bin;C:\Program Files (x86)\GNU\GnuPG\pub;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\Tools\Binn\;C:\Program Files\Microsoft SQL Server\100\DTS\Binn\;C:\Program Files (x86)\Microsoft SQL Server\100\Tools\Binn\VSShell\Common7\IDE\;C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies\;C:\Program Files (x86)\Microsoft SQL Server\100\DTS\Binn\;d:\Users\user\.dnx\bin;C:\Program Files\Microsoft DNX\Dnvm\;C:\Program Files (x86)\Windows Kits\8.1\Windows Performance Toolkit\;C:\Program Files\Microsoft SQL Server\120\Tools\Binn\;C:\Program Files\Microsoft SQL Server\130\Tools\Binn\;C:\Program Files (x86)\Skype\Phone\;d:\Users\user\.dnx\bin;d:\Users\user\Anaconda2;d:\Users\user\Anaconda2\Scripts;d:\Users\user\Anaconda2\Library\bin;C:\Program Files (x86)\apache-maven-3.3.9\bin 
	
	D:\project\_wcfLoadTest\tools.jni4net\WcfLoadTest.WcfServiceClientPublic>call build.cmd 
	compile classes
	WcfLoadTest.WcfServiceClientPublic.j4n.jar 
	WcfLoadTest.WcfServiceClientPublic.j4n.dll 
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(159,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Closed"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(139,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(159,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closed" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(168,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(177,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Closing"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(168,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(177,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(186,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(195,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Faulted"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(186,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(195,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(204,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(213,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "Opened"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(204,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(213,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(339,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(348,103): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel" уже содержит определение для "UnknownMessageReceived"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(339,103): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencebasichttp\IServiceBasicHttpChannel.generated.cs(348,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceBasicHttp.__IServiceBasicHttpChannel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(159,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel" уже содержит определение для "Closed"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(139,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(159,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Closed" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(168,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(177,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel" уже содержит определение для "Closing"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(168,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(177,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(186,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(195,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel" уже содержит определение для "Faulted"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(186,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(195,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(204,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(213,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel" уже содержит определение для "Opened"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(204,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(213,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(339,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(348,103): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel" уже содержит определение для "UnknownMessageReceived"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(339,103): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencenettcp\IServiceNetTcpChannel.generated.cs(348,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceNetTcp.__IServiceNetTcpChannel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(159,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel" уже содержит определение для "Closed"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(139,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(159,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Closed" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(168,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(177,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel" уже содержит определение для "Closing"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(168,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(177,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(186,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(195,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel" уже содержит определение для "Faulted"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(186,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(195,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(204,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(213,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel" уже содержит определение для "Opened"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(204,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(213,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(339,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(348,103): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel" уже содержит определение для "UnknownMessageReceived"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(339,103): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoap11\IServiceSoap11Channel.generated.cs(348,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoap11.__IServiceSoap11Channel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(159,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel" уже содержит определение для "Closed"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(139,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(159,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Closed" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(168,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(177,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel" уже содержит определение для "Closing"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(168,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(177,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Closing" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(186,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(195,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel" уже содержит определение для "Faulted"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(186,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(195,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Faulted" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(204,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(213,50): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel" уже содержит определение для "Opened"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(204,50): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(213,50): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.Opened" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(339,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(348,103): error CS0102: Класс "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel" уже содержит определение для "UnknownMessageReceived"
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(339,103): (Местоположение символа относительно предыдущей ошибки)
	clr\wcfloadtest\wcfserviceclientpublic\servicereferencesoapmsbin1\IServiceSoapMsBin1Channel.generated.cs(348,103): error CS0065: "WcfLoadTest.WcfServiceClientPublic.ServiceReferenceSoapMsBin1.__IServiceSoapMsBin1Channel.UnknownMessageReceived" : свойство события должно иметь и функцию доступа add, и remove
	compiling usage
	Для продолжения нажмите любую клавишу . . . 



