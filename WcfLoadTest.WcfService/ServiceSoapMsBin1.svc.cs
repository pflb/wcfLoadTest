using System;
using System.IO;
using System.Web.Hosting;

namespace WcfLoadTest.WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceSoapMsBin1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы ServiceSoapMsBin1.svc или ServiceSoapMsBin1.svc.cs в обозревателе решений и начните отладку.
    public class ServiceSoapMsBin1 : IServiceSoapMsBin1
    {
        string getFilePath(int fileSize)
        {
            string fileName = "file_" + fileSize.ToString() + ".bin";
            string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", fileName);
            return path;
        }

        public void Init()
        {
            int[] fileSizes = GetFileSizes();

            foreach (int fileSize in fileSizes)
            {
                string fileName = getFilePath(fileSize);

                if (!File.Exists(fileName))
                {
                    FileStream file = new FileStream(fileName, FileMode.Create);
                    long mbyte = Convert.ToInt64(fileSize) * 1024 * 1024;
                    long count = 0;
                    for (count = 0; count < mbyte; count++)
                    {
                        file.WriteByte(1);
                        if (count % (10 * 1024 * 1024) == 0)
                            file.Flush();
                    }
                    file.Close();
                }

            }
        }

        public int[] GetFileSizes()
        {
            int[] fileSizes;
            fileSizes = new int[5];
            fileSizes[0] = 1;
            fileSizes[1] = 2;
            fileSizes[2] = 10;
            fileSizes[3] = 20;
            fileSizes[4] = 50;

            return fileSizes;
        }

        public Stream GetFileBySize(int fileSize)
        {
            string fileName = getFilePath(fileSize);
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(String.Format("Файл размером \"{0}\" мега байт недоступен", fileSize));
            }
            FileStream file = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            return file;
        }

        public Int64 LoadFileAndReturnFileSizeInBytes(Stream file)
        {
            int readSize = 0;
            Int64 totalReadSize = 0;
            int readBufferSize = 1000;
            byte[] readBuffer = new byte[readBufferSize];
            do
            {
                readSize = file.Read(readBuffer, 0, readBufferSize);
                totalReadSize += Convert.ToInt64(readSize);
            }
            while (readSize > 0);
            file.Close();

            return totalReadSize;
        }

        public int GetIntValue(int value)
        {
            return value;
        }
    }
}
