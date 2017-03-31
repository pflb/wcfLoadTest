# Описание

Проект был создан для демонстрации того, что из **Apache.JMeter** можно подавать нагрузку на DCOM и WCF-сервисы. Причём даже на WCF-сервисы, которые используют в качестве протоколов *HTTP Soap/MsBin1* или *net.tcp*.

Первоначальная задача была в том, чтобы показать, что **Apache.JMeter** достаточно удобный инструмент.

Вторая задача в создании учебного примера, демонстрирующего различные подходы для разработки нагрузочных тестов для *DCOM* и *WCF* с использованием трёх популярных инструментов нагрузочного тестирования:

* **Visual Studio Enterprise** 2015;
* **HP LoadRunner** 12.53;
* **Apache.JMeter** 3.1.


# Состав проекта

![](wcf_dcom.png)

Логические части проекта:

* Пример теста для DCOM;
* Пример теста для WCF;
* Документация.

Состав:

* Проекты для теста DCOM:
	1. ![](img/dll.ico.png) DcomLoadTest.DcomClient
	2. ![](img/exe.ico.png) DcomLoadTest.DcomClientTestApplication
	3. ![](img/dll.ico.png) DcomLoadTest.JMeterAction
	4. ![](img/exe.ico.png) DcomLoadTest.JMeterActionTestApplication
	5. ![](img/java.jar.ico.png) jni4net.dcomLoadTest.JMeterAction
	6. ![](img/hp.ico.png) loadTest.HpLoadRunner.Dcom
	7. ![](img/hp.ico.png) loadTest.HpLoadRunner.DcomRecordDcom
	8. ![](img/hp.ico.png) loadTest.HpLoadRunner.DcomRecordDotnet
	9. ![](img/jmx.ico.png) loadTest.JMeter.Dcom
	10. ![](img/csproj.ico.png) loadTest.VisualStudio.DcomLoadTest
	11. ![](img/csproj.ico.png) loadTest.VisualStudio.DcomModuleTest
	12. ![](img/exe.ico.png) Tools.ActionFileSplitter
	13. ![](img/exe.ico.png) tools.ComView


* Проекты для теста WCF:
	1. ![](img/json.ico.png) GrafanaTemplates
	2. ![](img/dll.ico.png) InfluxDbWcfTraceListener
	2. ![](img/java.jar.ico.png) jni4net.wcfLoadTest.JMeterAction
	3. ![](img/hp.ico.png) loadTest.HpLoadRunner.Wcf
	4. ![](img/hp.ico.png) loadTest.HpLoadRunner.WcfRecordDotnet
	5. ![](img/jmx.ico.png) loadTest.JMeter.Wcf
	6. ![](img/csproj.ico.png) loadTest.VisualStudio.WcfLoadTest
	7. ![](img/csproj.ico.png) loadTest.VisualStudio.WcfModuleTest
	8. ![](img/dll.ico.png) WcfLoadTest.JMeterAction
	9. ![](img/exe.ico.png) WcfLoadTest.JMeterActionTestApplication
	10. ![](img/svc.ico.png) WcfLoadTest.WcfService
	11. ![](img/dll.ico.png) WcfLoadTest.WcfServiceClient
	12. ![](img/exe.ico.png) WcfLoadTest.WcfServiceClientTestApplication

* Документация и общие проекты:
	1. ![](img/dir.ico.png) docs
	1. ![](img/txt.ico.png) readme.md
	2. ![](img/dll.ico.png) JMeter.Data
	3. ![](img/exe.ico.png) tools.jni4net


## Проекты для теста DCOM

![](dcom.png)

### ![](img/exe.ico.png) Microsoft Office Word

Это сторонний продукт из состава **Microsoft Office**.

DCOM-сервисом является приложение **Microsoft Office Word**, локально установленный. Предполагается, что он установлен и зарегистрирован на нагрузочной станции. Это приложение не является частью проекта.

DCOM-сервис используется:

1. Клиентской библиотекой **DcomLoadTest.DcomClient**.

### ![](img/exe.ico.png) tools.ComView

Это сторонняя утилита. В составе  исполняемый файл и файл справки. Сайт проекта: http://www.japheth.de/COMView.html. В данный момент сайт неактивен, но доступен по ссылкам из проекта archive.org.

Если нужно зарегистрировать или разрегистрировать другой DCOM-сервис, то может пригодиться утилита **ComView**.

От утилиты напрямую не зависят другие части проекта. Утилита является вспомогательной.

### ![](img/dll.ico.png)  DcomLoadTest.DcomClient

Для взаимодействия с DCOM-сервисом из dotNet-среды, создан проект клиента на C#. В данном случае, это обёртка нам методами DCOM-сервиса, предоставляемого **Microsoft Office Word**.

Клиентская библиотека **DcomLoadTest.DcomClient** используется:

1. Тестовым приложением **DcomLoadTest.DcomClientTestApplication**.
2. Нагрузочным тестом **loadTest.HpLoadRunner.Dcom** для **HP LoadRunner**.
3. Проектом **DcomLoadTest.JMeterAction**, реализующим сценарий для **Apache.JMeter**
4. Нагрузочным тестом **loadTest.VisualStudio.DcomLoadTest** 
5. Нагрузочным тестом **loadTest.VisualStudio.DcomModuleTest**

### ![](img/exe.ico.png) DcomLoadTest.DcomClientTestApplication

Для проверки того, что проект **DcomLoadTest.DcomClient** работает и взаимодействие с **Microsoft Office Word** осуществляется корректно создано тестовое консольное приложение на C#.

Приложение **DcomLoadTest.DcomClientTestApplication** также используется для демонстрации работы Recorder-а в **HP LoadRunner Virtual User Generator**. Схема взаимодействия такая - **Virtual User Generator** запускает тестовое приложение **DcomLoadTest.DcomClientTestApplication**, перехватывает его вызовы dotNet-методов или DCOM-запросы и ответы и формирует заготовку нагрузочного скрипта.

### ![](img/dll.ico.png) DcomLoadTest.JMeterAction

Сценарии для **Apache.JMeter** реализованы в виде методов на C#, которые возвращают объект **SampleResults** из библиотеки **JMeter.Data**. Методы собраны в тестовые классы, которые собраны в виде библиотеки **DcomLoadTest.JMeterAction**.

То есть, сценарий для **JMeter** пишется для на C# в виде методов `Action*` и отлаживается в **Visual Studio**. Методы называются `Action`, для единообразия с тестами **HP LoadRunner**. А **Jmeter** вызывает Action-методы dll-библиотеки, при выполнении которых создаётся нагрузка на тестируемый DCOM-сервис. Action-методы возвращают статистику по выполнению каждого запроса к DCOM-сервису. И **JMeter** отображает транзакции из сценария, как подзапросы.

### ![](img/exe.ico.png) DcomLoadTest.JMeterActionTestApplication
  
Для отладки сценариев для Apache.JMeter в Visual Studio нужна простая программа, вызывающая методы Action-методы.
**DcomLoadTest.JMeterActionTestApplication** - простая программа, которая используется для отладки Action-методов в **Visual Studio**.


### ![](img/java.jar.ico.png) jni4net.dcomLoadTest.JMeterAction

Apache.JMeter штатными средствами может вызывать методы из java-классов, а также исполняемые файлы. То есть, можно подавать нагрузку запуском **DcomLoadTest.JMeterActionTestApplication**. Для того, чтобы вызывать Action-методы, реализованные в dotNet библиотеке, с помощью jni4net создаётся java-класс-обёртка 

## Пример теста для WCF

![](wcf.png)


