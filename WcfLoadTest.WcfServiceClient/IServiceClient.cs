using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLoadTest.WcfServiceClient
{
    public interface IServiceClient
    {
        void Init();
        long LoadFileAndReturnFileSizeInBytes(System.IO.Stream file);
        System.IO.Stream GetFileBySize(int fileSize);
        int[] GetFileSizes();
        int GetIntValue(int value);
        void Close();
    }
}
