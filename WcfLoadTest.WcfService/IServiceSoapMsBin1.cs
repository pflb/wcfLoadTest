using System;
using System.IO;
using System.ServiceModel;

namespace WcfLoadTest.WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceSoapMsBin1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServiceSoapMsBin1
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
