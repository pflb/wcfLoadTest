using WcfLoadTest.JMeterAction;
using JMeter.Data;
using System;
using System.Collections.Generic;

namespace WcfLoadTest.JMeterActionTestApplication
{
    class Program
    {
        static void PrintResults(Results result)
        {
            foreach (var r in result.SampleResults)
            {
                Console.WriteLine($"{r.sampleStartStr} {r.isSuccess} {r.loadTime} {r.label}");
                if (!r.isSuccess)
                    Console.WriteLine(r.responceMessage);
            }
        }
        static void Main(string[] args)
        {
            #region прогрев
            {
                (new Scenario1BasicHttpClient()).exec(1);
                (new Scenario1NetTcpClientxN()).exec(1);
                (new Scenario1Soap11ClientxN()).exec(1);
                (new Scenario1SoapMsBin1Client()).exec(1);
            }
            #endregion

            {
                var scenario = new Scenario1BasicHttpClient();
                Results result = scenario.exec(5);
                PrintResults(result);
            }


            {
                var scenario = new Scenario1NetTcpClientxN();
                Results result = scenario.exec(5);
                PrintResults(result);
            }

            {
                var scenario = new Scenario1Soap11ClientxN();
                Results result = scenario.exec(5);
                PrintResults(result);
            }

            {
                var scenario = new Scenario1SoapMsBin1Client();
                Results result = scenario.exec(5);
                PrintResults(result);
            }
            Console.ReadKey();
        }
    }
}
