using JMeter.Data;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.JMeterAction
{
    public class Scenario1BasicHttpClient
    {
        Scenario1xN<ServiceBasicHttpClient> scenario = new Scenario1xN<ServiceBasicHttpClient>();

        public Results exec(int N)
        {
            return scenario.exec(N, "ServiceBasicHttpClient");
        }
    }
}
