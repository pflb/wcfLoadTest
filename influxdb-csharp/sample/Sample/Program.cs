﻿using InfluxDB.Collector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var p = new Program();
            p.Exec();
        }

        public void Exec()
        {
            Collect().Wait();
        }

        async Task Collect()
        {
            var process = Process.GetCurrentProcess();

            Metrics.Collector = new CollectorConfiguration()
                .Tag.With("host", Environment.GetEnvironmentVariable("COMPUTERNAME"))
                .Tag.With("os", Environment.GetEnvironmentVariable("OS"))
                .Tag.With("process", Path.GetFileName(process.MainModule.FileName))
                .Batch.AtInterval(TimeSpan.FromSeconds(2))
                .WriteTo.InfluxDB("http://192.168.99.100:8086", "data")
                .CreateCollector();

            while (true)
            {
                Metrics.Increment("iterations");

                Metrics.Write("cpu_time",
                    new Dictionary<string, object>
                    {
                        { "value", process.TotalProcessorTime.TotalMilliseconds },
                        { "user", process.UserProcessorTime.TotalMilliseconds }
                    });

                Metrics.Measure("working_set", process.WorkingSet64);

                await Task.Delay(1000);
            }
        }
    }
}
