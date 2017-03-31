using System;
using System.IO;
using System.ServiceModel;

namespace WcfLoadTest.WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceBasicHttp" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceBasicHttp
    {
        [OperationContract]
        void Init();

        [OperationContract]
        Int64 LoadFileAndReturnFileSizeInBytes(Stream file);

        [OperationContract]
        Stream GetFileBySize(int fileSize);

        [OperationContract]
        int[] GetFileSizes();

        [OperationContract]
        int GetIntValue(int value);
    }
}
