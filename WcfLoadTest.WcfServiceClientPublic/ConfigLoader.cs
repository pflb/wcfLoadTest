using System;
using System.Reflection;

namespace WcfLoadTest.WcfServiceClientPublic
{
    public static class ConfigLoader
    {
        public static void Load()
        {
            AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE",
                Assembly.GetExecutingAssembly().Location + ".config");
        }
    }
}
