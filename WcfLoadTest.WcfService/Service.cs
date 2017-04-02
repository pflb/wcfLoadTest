using System;
using System.IO;
using System.Web.Hosting;

namespace WcfLoadTest.WcfService
{
    class Service : IServiceBasicHttp, IServiceNetTcp, IServiceSoapMsBin1, IServiceSoap11
    {
        int[] fileSizes;

        string GetFilePath(int fileSize)
        {
            string fileName = "file_" + fileSize.ToString() + ".bin";
            string path = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, "App_Data", fileName);
            return path;
        }

        public void Init()
        {
            fileSizes = GetFileSizes();

            foreach (int fileSize in fileSizes)
            {
                string fileName = GetFilePath(fileSize);

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
            if (this.fileSizes == null)
            {
                char[] separator = { ',' };
                string[] fileSizesStr = System.Configuration.ConfigurationManager.AppSettings["fileSizes"]
                    .Split(separator, StringSplitOptions.RemoveEmptyEntries);
                this.fileSizes = new int[fileSizesStr.Length];
                for (int i = 0; i < fileSizesStr.Length; i++)
                {
                    this.fileSizes[i] = Int32.Parse(fileSizesStr[i]);
                }
            }
            return this.fileSizes;
        }

        public Stream GetFileBySize(int fileSize)
        {
            string fileName = GetFilePath(fileSize);
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