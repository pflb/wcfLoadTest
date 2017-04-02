using System;
using System.IO;
using System.Web.Hosting;

namespace WcfLoadTest.WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceBasicHttp" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServiceBasicHttp.svc или ServiceBasicHttp.svc.cs в обозревателе решений и начните отладку.
    public class ServiceBasicHttp : IServiceBasicHttp
    {
        Service service;

        public ServiceBasicHttp()
        {
            service = new Service();
        }

        public void Init()
        {
            service.Init();
        }

        public int[] GetFileSizes()
        {
            return service.GetFileSizes();
        }

        public Stream GetFileBySize(int fileSize)
        {
            return service.GetFileBySize(fileSize);
        }

        public Int64 LoadFileAndReturnFileSizeInBytes(Stream file)
        {
            return service.LoadFileAndReturnFileSizeInBytes(file);
        }

        public int GetIntValue(int value)
        {
            return service.GetIntValue(value);
        }
    }
}
