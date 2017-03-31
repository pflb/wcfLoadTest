using JMeter.Data;
using System;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.JMeterAction
{
    public class Scenario1Soap11ClientxN
    {
        void execScenario(int N, Results lr)
        {
            lr.Start("ServiceSoap11Client");

            lr.Start("ServiceSoap11Client.Init()");
            {
                var client = new ServiceSoap11Client();
                client.Init();
                client.Close();
            }
            lr.End();


            lr.Start($"ServiceSoap11Client.GetFileSizes() x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start("ServiceSoap11Client.GetFileSizes()");
                var client = new ServiceSoap11Client();
                client.GetFileSizes();
                client.Close();
                lr.End();
            }
            lr.End();

            lr.Start($"ServiceSoap11Client.GetIntValue(...) x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start("ServiceSoap11Client.GetIntValue(...)");
                var client = new ServiceSoap11Client();
                client.GetIntValue(i);
                client.Close();
                lr.End();
            }
            lr.End();

            int[] fileSizes;
            {
                lr.Start($"ServiceSoap11Client.GetFileSizes()");
                var client = new ServiceSoap11Client();
                fileSizes = client.GetFileSizes();
                client.Close();
                lr.End();
            }

            #region GetFiles
            lr.Start($"ServiceSoap11Client.GetFileBySize(...) x { fileSizes.Length } x {N}");
            for(int i = 0; i < N; i++)
            { 
                foreach (var fileSize in fileSizes)
                {
                    lr.Start($"ServiceSoap11Client.GetFileBySize({fileSize})");
                    var client = new ServiceSoap11Client();
                    var file = client.GetFileBySize(fileSize);
                    client.Close();
                    lr.End();
                }
            }
            lr.End();
            #endregion GetFiles

            lr.End();
        }

        public Results exec(int N)
        {
            Results lr = new Results();
            try
            {
                execScenario(N, lr);
            }
            catch (Exception e)
            {
                lr.End(e);
            }
            return lr;
        }
    }
}
