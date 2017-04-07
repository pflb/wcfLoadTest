using JMeter.Data;
using System;
using WcfLoadTest.JMeterAction;

namespace WcfLoadTest.JMeterActionTestApplication
{
    class Program
    {
        static void PrintResults(Results result)
        {
            foreach (var r in result.SampleResults)
            {
                if (!r.isSuccess)
                {
                    var fColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{r.sampleStartStr} {r.isSuccess} {r.loadTime} {r.label}");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(r.responceMessage);
                    Console.ForegroundColor = fColor;
                }
                else
                {
                    Console.WriteLine($"{r.sampleStartStr} {r.isSuccess} {r.loadTime} {r.label}");
                }
                    
            }
        }
        static void Main(string[] args)
        {
            #region прогрев
            {
                PrintResults((new Scenario1BasicHttpClient()).exec(1));
                PrintResults((new Scenario1NetTcpClientxN()).exec(1));
                PrintResults((new Scenario1Soap11ClientxN()).exec(1));
                PrintResults((new Scenario1SoapMsBin1Client()).exec(1));
            }
            #endregion
            Console.ReadKey();
        }
    }
}
