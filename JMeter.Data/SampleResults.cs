using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace JMeter.Data
{
    [DataContract]
    public class Results
    {
        Dictionary<string, DictionaryItem> WatchResults = new Dictionary<string, DictionaryItem>();
        List<SampleResult> sampleResultList;
        DateTime? sampleStartTime;
        Stack<string> labels = new Stack<string>();

        public int ERROR { get { return 500; } }
        public int OK { get { return 200; } }
        public int AUTO { get { return OK; } }

        [DataMember]
        public long sampleStart
        {
            get
            {
                long ticks = sampleStartTime.Value.Ticks;
                return ticks;
            }
            set { var a = value; }
        }

        [DataMember]
        public SampleResult[] SampleResults { get { return sampleResultList.ToArray(); } }

        [DataMember]
        bool isSuccess = true;

        public Results()
        {
            sampleResultList = new List<SampleResult>();
        }

        string ExceptionToString(Exception ex)
        {
            string result = "";
            if(ex != null)
            {
                result = ex.Message;
                result += "\n" + ex.StackTrace;

                if(ex.InnerException != null)
                {
                    result += "\n\n";
                    result += ExceptionToString(ex.InnerException);
                }
            }
            return result;
        }
        public SampleResult Start(string label)
        {
            var sampleResult = new SampleResult(label);
            sampleResultList.Add(sampleResult);
            labels.Push(label);
            var dicItem = new DictionaryItem()
            {
                SampleResult = sampleResult,
                Stopwatch = new System.Diagnostics.Stopwatch()
            };
            dicItem.Stopwatch.Start();

            WatchResults.Add(label, dicItem);

            sampleResult.Start();
            if (sampleStartTime == null)
            {
                sampleStartTime = DateTime.Now;
            }
            return sampleResult;
        }

        public void End()
        {            
            end_transaction(labels.Pop(), AUTO);
        }

        public void End(int code)
        {
            end_transaction(labels.Pop(), code);
        }

        public void End(Exception e)
        {
            end_transaction(labels.Pop(), e);
        }


        public SampleResult start_transaction(string label)
        {
            return Start(label);
        }

        public void end_transaction(string label, int code)
        {
            DictionaryItem dicItem = WatchResults[label];
            WatchResults.Remove(label);

            dicItem.Stopwatch.Stop();
            if (code == OK)
            {
                dicItem.SampleResult.End(true, "200", "", dicItem.Stopwatch.ElapsedMilliseconds);
            }
            else
            {
                dicItem.SampleResult.End(false, "500", "", dicItem.Stopwatch.ElapsedMilliseconds);
                this.isSuccess = false;
            }
        }

        public void end_transaction(string label, Exception e)
        {
            DictionaryItem dicItem = WatchResults[label];
            WatchResults.Remove(label);

            dicItem.Stopwatch.Stop();
            string errorMessage = ExceptionToString(e);
            dicItem.SampleResult.End(false, "500", errorMessage, dicItem.Stopwatch.ElapsedMilliseconds);

            foreach (string key in WatchResults.Keys)
            {
                DictionaryItem watchResult = WatchResults[key];
                watchResult.Stopwatch.Stop();
                watchResult.SampleResult.End(false, "400", errorMessage, watchResult.Stopwatch.ElapsedMilliseconds);
            }
            WatchResults.Clear();
            this.isSuccess = false;
        }

        public void end_transaction(Exception e)
        {
            end_transaction(labels.Pop(), e);
        }


        public override string ToString()
        {
            var stream1 = new MemoryStream();
            var serial = new DataContractJsonSerializer(typeof(Results));
            serial.WriteObject(stream1, this);
            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }
    }
}
