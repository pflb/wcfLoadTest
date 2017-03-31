using ServiceNetTcpClientBase = WcfLoadTest.WcfServiceClient.ServiceReferenceNetTcp.ServiceNetTcpClient;

namespace WcfLoadTest.WcfServiceClient
{
    public class ServiceNetTcpClient : IServiceClient
    {
        ServiceNetTcpClientBase Client { get; set; }

        public ServiceNetTcpClient()
        {
            Client = new ServiceNetTcpClientBase();
        }

        public void Init()
        {
            Client.Init();
        }

        public long LoadFileAndReturnFileSizeInBytes(System.IO.Stream file)
        {
            return Client.LoadFileAndReturnFileSizeInBytes(file);
        }

        public System.IO.Stream GetFileBySize(int fileSize)
        {
            return Client.GetFileBySize(fileSize);
        }

        public int[] GetFileSizes()
        {
            return Client.GetFileSizes();
        }

        public int GetIntValue(int value)
        {
            return Client.GetIntValue(value);
        }

        public void Close()
        {
            Client.Close();
        }
    }
}
