using System;
using System.Reflection;

namespace WcfLoadTest.JMeterAction
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
