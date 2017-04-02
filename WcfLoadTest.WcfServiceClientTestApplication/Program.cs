using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.WcfServiceClientTestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var client = new ServiceBasicHttpClient();
                client.Init();
                client.Close();
            }
        }
    }
}
