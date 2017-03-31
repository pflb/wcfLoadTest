using ServiceSoap11ClientBase = WcfLoadTest.WcfServiceClient.ServiceReferenceSoap11.ServiceSoap11Client;

namespace WcfLoadTest.WcfServiceClient
{
    public class ServiceSoap11Client : IServiceClient
    {
        ServiceSoap11ClientBase Client { get; set; }

        public ServiceSoap11Client()
        {
            Client = new ServiceSoap11ClientBase();
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
