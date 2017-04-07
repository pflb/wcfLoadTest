using System;
using System.IO;
using System.Linq;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.WcfServiceClientTestApplication
{
    class Program
    {
        static void PrintException(string serviceClientName, Exception ex)
        {
            var forColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{serviceClientName} : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(ex.StackTrace);
            Console.ForegroundColor = forColor;

            if(ex.InnerException != null)
            {
                PrintException(serviceClientName, ex.InnerException);
            }
        }
        static void Main(string[] args)
        {
            {
                var client = new ServiceSoap11Client();
                client.Init();
                int i1 = client.GetIntValue(1);
                int i2 = client.GetIntValue(2);
                Console.WriteLine($"{i1}, {i2}");
                int[] fileSizes = client.GetFileSizes();
                for(int i = 0; i < 1; i++)
                foreach(int fileSize in fileSizes.Where(fs => fs <= 300))
                {
                    long uploadFileSize = default(long);

                    try
                    {
                        Stream file = client.GetFileBySize(fileSize);
                        uploadFileSize = client.LoadFileAndReturnFileSizeInBytes(file);
                    }
                    catch(Exception ex)
                    {
                        PrintException("ServiceSoap11Client", ex);
                    }
                    finally
                    {
                        Console.WriteLine($"File Size: {fileSize} - {uploadFileSize}");
                    }
                }
                client.Close();
            }            
            Console.ReadKey();
        }
    }
}
