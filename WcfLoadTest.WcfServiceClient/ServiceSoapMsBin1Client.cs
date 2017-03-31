using ServiceSoapMsBin1ClientBase = WcfLoadTest.WcfServiceClient.ServiceReferenceSoapMsBin1.ServiceSoapMsBin1Client;

namespace WcfLoadTest.WcfServiceClient
{
    public class ServiceSoapMsBin1Client : IServiceClient
    {
        ServiceSoapMsBin1ClientBase Client { get; set; }

        public ServiceSoapMsBin1Client()
        {
            Client = new ServiceSoapMsBin1ClientBase();
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
