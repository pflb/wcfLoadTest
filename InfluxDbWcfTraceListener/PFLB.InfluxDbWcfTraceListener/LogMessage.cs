using InfluxDB.LineProtocol.Payload;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PFLB
{
    class LogMessage
    {
        public string Time { get; set; }
        public string Action { get; set; }
        public string MessageId { get; set; }
        public string User { get; set; }
        public string Service { get; set; }
        public string Status { get; set; }

        public DateTime StartTime { get; set; }
        public double DurationMillisecond { get; set; }


        public LogMessage(string time, Match match)
        {
            Time = time;

            Action = match.Groups[1].Value;
            MessageId = match.Groups[2].Value;
            User = match.Groups[3].Value;
            Service = match.Groups[4].Value;

            //TODO: опасный момент, зависимость от региональных настроек
            StartTime = DateTime.Parse(Time).ToUniversalTime();
        }

        public void SetEndTime(DateTime endTime)
        {
            var duration = endTime.ToUniversalTime().Subtract(StartTime);
            DurationMillisecond = duration.TotalMilliseconds;
        }

        public void SetStatusOK()
        {
            Status = "OK";
        }

        public void SetStatusError()
        {
            Status = "Error";
        }

        public void SetEndTime(string endTime)
        {
            //TODO: опасный момент, зависимость от региональных настроек
            SetEndTime(DateTime.Parse(endTime));
        }

        public LineProtocolPoint ToLineProtocolPoint(string measure)
        {
            var icdbTime = new LineProtocolPoint(
                measure,
                new Dictionary<string, object>
                {
                    { "value", this.DurationMillisecond },
                },
                new Dictionary<string, string>
                {
                    { "Host", Environment.GetEnvironmentVariable("COMPUTERNAME") },
                    { "Action",  this.Action },
                    { "Service",  this.Service },
                    { "User",  this.User },
                    { "Status",  this.Status },
                },
                    StartTime
                );
            return icdbTime;
        }
    }
}
