using JMeter.Data;
using WcfLoadTest.WcfServiceClient;
using System;

namespace WcfLoadTest.JMeterAction
{
    class Scenario1xN<T> where T : IServiceClient, new()
    {
        void execScenario(int N, string clientName, Results lr)
        {
            lr.Start(clientName);

            lr.Start($"{clientName}.Init()");
            {
                var client = new T();
                client.Init();
                client.Close();
            }
            lr.End();

            #region GetFileSizes
            lr.Start($"{clientName}.GetFileSizes() x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start($"{clientName}.GetFileSizes()");
                var client = new T();
                client.GetFileSizes();
                client.Close();
                lr.End();
            }
            lr.End();
            #endregion GetFileSizes

            #region GetIntValue
            lr.Start($"{clientName}.GetIntValue(...) x {N}");
            for (int i = 0; i < N; i++)
            {
                lr.Start($"{clientName}.GetIntValue(...)");
                var client = new T();
                client.GetIntValue(i);
                client.Close();
                lr.End();
            }
            lr.End();
            #endregion GetIntValue

            int[] fileSizes;
            {
                lr.Start($"{clientName}.GetFileSizes()");
                var client = new T();
                fileSizes = client.GetFileSizes();
                client.Close();
                lr.End();
            }

            #region GetFiles
            lr.Start($"{clientName}.GetFileBySize(...) x { fileSizes.Length } x {N}");
            for(int i = 0; i < N; i++)
            { 
                foreach (var fileSize in fileSizes)
                {                
                    lr.Start($"{clientName}.GetFileBySize({fileSize})");
                    var client = new T();
                    var file = client.GetFileBySize(fileSize);
                    client.Close();
                    lr.End();                
                }
            }
            lr.End();
            #endregion GetFiles

            #region GetFiles and LoadFiles
            lr.Start($"{clientName}.GetFileBySize(...) x { fileSizes.Length } x {N}");
            for (int i = 0; i < N; i++)
            {
                foreach (var fileSize in fileSizes)
                {
                    lr.Start($"{clientName}.GetFileBySize({fileSize}) & {clientName}.LoadFileAndReturnFileSizeInBytes({fileSize} bytes file)");
                    var client = new T();
                    lr.Start($"{clientName}.GetFileBySize({fileSize})");
                    var file = client.GetFileBySize(fileSize);
                    lr.End();
                    lr.Start($"{clientName}.LoadFileAndReturnFileSizeInBytes({fileSize} bytes file)");
                    var uploadFileSize = client.LoadFileAndReturnFileSizeInBytes(file);
                    lr.End();
                    client.Close();
                    lr.End();
                }
            }
            lr.End();
            #endregion GetFiles and LoadFiles

            lr.End();
        }

        public Results exec(int N, string clientName)
        {
            Results lr = new Results();
            try
            {
                execScenario(N, clientName, lr);
            }
            catch (Exception e)
            {
                lr.End(e);
            }
            return lr;
        }
    }
}
