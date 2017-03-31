using ServiceBasicHttpClientBase = WcfLoadTest.WcfServiceClient.ServiceReferenceBasicHttp.ServiceBasicHttpClient;

namespace WcfLoadTest.WcfServiceClient
{
    public class ServiceBasicHttpClient : IServiceClient
    {
        ServiceBasicHttpClientBase Client { get; set; }


        public ServiceBasicHttpClient()
        {
            Client = new ServiceBasicHttpClientBase();
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
