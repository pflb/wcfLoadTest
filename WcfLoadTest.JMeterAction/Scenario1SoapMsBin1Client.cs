using JMeter.Data;
using WcfLoadTest.WcfServiceClient;

namespace WcfLoadTest.JMeterAction
{
    public class Scenario1SoapMsBin1Client
    {
        Scenario1xN<ServiceSoapMsBin1Client> scenario = new Scenario1xN<ServiceSoapMsBin1Client>();

        public Results exec(int N)
        {
            return scenario.exec(N, "ServiceSoapMsBin1Client");
        }
    }
}
