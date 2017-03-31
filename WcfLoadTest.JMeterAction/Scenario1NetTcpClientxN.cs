using JMeter.Data;
using System;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.JMeterAction
{
    public class Scenario1NetTcpClientxN
    {
        void execScenario(int N, Results lr)
        {
            lr.Start("ServiceNetTcpClient");

            lr.Start("ServiceNetTcpClient.Init()");
            {
                var client = new ServiceNetTcpClient();
                client.Init();
                client.Close();
            }
            lr.End();


            lr.Start($"ServiceNetTcpClient.GetFileSizes() x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start("ServiceNetTcpClient.GetFileSizes()");
                var client = new ServiceNetTcpClient();
                client.GetFileSizes();
                client.Close();
                lr.End();
            }
            lr.End();

            lr.Start($"ServiceNetTcpClient.GetIntValue(...) x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start("ServiceNetTcpClient.GetIntValue(...)");
                var client = new ServiceNetTcpClient();
                client.GetIntValue(i);
                client.Close();
                lr.End();
            }
            lr.End();

            int[] fileSizes;
            {
                lr.Start($"ServiceNetTcpClient.GetFileSizes()");
                var client = new ServiceNetTcpClient();
                fileSizes = client.GetFileSizes();
                client.Close();
                lr.End();
            }

            #region GetFiles
            lr.Start($"ServiceNetTcpClient.GetFileBySize(...) x { fileSizes.Length } x {N}");
            for(int i = 0; i < N; i++)
            {
                foreach (var fileSize in fileSizes)
                {
                    lr.Start($"ServiceNetTcpClient.GetFileBySize({fileSize})");
                    var client = new ServiceNetTcpClient();
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
