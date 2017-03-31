using System;
using System.Runtime.Serialization;

namespace JMeter.Data
{
    [DataContract]
    public class SampleResult
    {
        DateTime unixStart = DateTime.Parse("1970-01-01");

        [DataMember]
        public string label;

        [DataMember]
        public long sampleStart
        {
            get
            {
                long ticks = sampleStartTime.ToUniversalTime().Ticks - unixStart.Ticks;
                return Convert.ToInt64(Math.Round(Convert.ToDouble(ticks) / 10000.0));
            }
            set { var a = value; }
        }
        [DataMember]
        public String sampleStartStr
        {
            get { return sampleStartTime.ToString("yyyy-MM-dd HH:mm:ss.ffff"); }
            set { var a = value; }
        }

        DateTime sampleStartTime;
        [DataMember]
        public long loadTime;
        [DataMember]
        public bool isSuccess;
        [DataMember]
        public string responceCode;
        [DataMember]
        public string responceMessage;

        public SampleResult(string label)
        {
            this.label = label;
        }

        public void Start()
        {
            sampleStartTime = DateTime.Now;
        }

        public void End(long elapsedMillisecond)
        {
            End(true, "200", "", elapsedMillisecond);
        }

        public void End(bool isSuccess, string responceCode, string responceMessage, long elapsedMillisecond)
        {
            this.loadTime = elapsedMillisecond;
            this.isSuccess = isSuccess;
            this.responceCode = responceCode;
            this.responceMessage = responceMessage;
        }
    }
}
