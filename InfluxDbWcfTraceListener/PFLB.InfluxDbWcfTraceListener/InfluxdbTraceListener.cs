using InfluxDB.LineProtocol.Client;
using InfluxDB.LineProtocol.Payload;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Permissions;
using System.Text.RegularExpressions;
using System.Timers;

namespace PFLB
{
    [HostProtectionAttribute(SecurityAction.LinkDemand, Synchronization = true)]
    public class InfluxdbTraceListener : TraceListener
    {
        string Measure { get; set; }
        int SaveCasheSize { get; set; }
        string Server { get; set; }
        string Database { get; set; }
        Timer saveTimer = new Timer();

        ConcurrentDictionary<String, LogMessage> messages;

        LineProtocolClient client;
        LogPoints logPoints = new LogPoints();

        Regex regexSend = new Regex(
            @"<a:Action s:mustUnderstand=""1"" xmlns:a=""http://www.w3.org/2005/08/addressing"">([^<]+)</a:Action>.*" +
            @"<a:MessageID xmlns:a=""http://www.w3.org/2005/08/addressing"">([^<]+)</a:MessageID>.*" +
            @"<User[^>]+>([^<]+)</User>.*" +
            @"<a:To s:mustUnderstand=""1"" xmlns:a=""http://www.w3.org/2005/08/addressing"">([^<]+)</a:To>",
            RegexOptions.Compiled
            );
        Regex regexReceiveOK = new Regex(
            @"<Action s:mustUnderstand=""1"" xmlns=""http://www.w3.org/2005/08/addressing"">([^<]+)</Action>.*" +
            @"<RelatesTo xmlns=""http://www.w3.org/2005/08/addressing"">([^<]+)</RelatesTo>.*",
            RegexOptions.Compiled
            );
        Regex regexReceiveFail = new Regex(
            @"<a:Action s:mustUnderstand=""1"" xmlns:a=""http://www.w3.org/2005/08/addressing"">" +
            @"http://www.w3.org/2005/08/addressing/soap/fault" +
            @"</a:Action><a:RelatesTo xmlns:a=""http://www.w3.org/2005/08/addressing"">" +
            @"([^<]+)" +
            @"</a:RelatesTo>",
            RegexOptions.Compiled
            );
        Regex regex = new Regex(
            @"<MessageLogTraceRecord Time=""([^""]+)"" Source=""([^""]+)""[^>]+>" +
            @"(<s:Envelope.*</s:Envelope>)" +
            @"</MessageLogTraceRecord>",
            RegexOptions.Compiled
            );
        public InfluxdbTraceListener() : base()
        {
        }
        public InfluxdbTraceListener(String settings) : base(settings)
        {
            try
            {
                Regex regex = new Regex("Server=([^;]+);Database=([^;]+);Measure=([^;]+);SaveCasheSize=([^;]+);SaveIntervalInSecond=([^;]+);");
                var match = regex.Match(settings);
                if (match.Success)
                {
                    Server = match.Groups[1].Value;
                    Database = match.Groups[2].Value;
                    this.Measure = match.Groups[3].Value;
                    this.SaveCasheSize = Int32.Parse(match.Groups[4].Value);
                    int saveIntervalInSecond = Int32.Parse(match.Groups[5].Value);
                    saveTimer.Interval = saveIntervalInSecond * 1000;
                    saveTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                    saveTimer.Enabled = true;
                    client = new LineProtocolClient(new Uri(Server), Database);
                }
                messages = new ConcurrentDictionary<string, LogMessage>();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message, e.StackTrace);
            }
        }
        public override void Write(string message)
        {
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Flush();
        }
        public override void Flush()
        {
            SendPoints();
            base.Flush();
        }
        async void SendPoints()
        {
            try
            {
                LogMessage[] messages = logPoints.Flush();
                if (messages.Length > 0)
                {
                    var payload = new LineProtocolPayload();
                    foreach (LogMessage logMessage in messages)
                    {
                        payload.Add(logMessage.ToLineProtocolPoint(Measure));
                    }
                    LineProtocolWriteResult influxResult = await client.WriteAsync(payload);
                    if (!influxResult.Success)
                        Debug.Fail(influxResult.ErrorMessage);
                }
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message, e.StackTrace);
            }
        }
        public override void WriteLine(string message)
        {
            try
            {
                if (message != null && message.StartsWith("<MessageLogTraceRecord ", StringComparison.InvariantCultureIgnoreCase))
                {

                    var match = regex.Match(message);
                    if (match.Success)
                    {
                        var time = match.Groups[1].Value;
                        var source = match.Groups[2].Value;

                        //

                        if (source == "TransportSend")
                        {
                            var sendMatch = regexSend.Match(match.Groups[3].Value);
                            if (sendMatch.Success)
                            {
                                var logMessage = new LogMessage(time, sendMatch);
                                messages.TryAdd(logMessage.MessageId, logMessage);
                            }
                        }
                        else if (source == "TransportReceive")
                        {
                            var receiveMatchOK = regexReceiveOK.Match(match.Groups[3].Value);
                            if (receiveMatchOK.Success)
                            {

                                string action = receiveMatchOK.Groups[1].Value;
                                Debug.Assert(@"http://www.w3.org/2005/08/addressing/soap/fault" != action);
                                string messageId = receiveMatchOK.Groups[2].Value;

                                LogMessage logMessage;
                                if (messages.TryRemove(messageId, out logMessage))
                                {
                                    logMessage.SetStatusOK();
                                    logMessage.SetEndTime(time);
                                    logPoints.Add(logMessage);
                                    if (logPoints.Count >= SaveCasheSize)
                                        Flush();
                                }
                            }
                            else
                            {
                                var receiveMatchFail = regexReceiveFail.Match(match.Groups[3].Value);
                                if (receiveMatchFail.Success)
                                {

                                    string messageId = receiveMatchFail.Groups[1].Value;

                                    LogMessage logMessage;
                                    if (messages.TryRemove(messageId, out logMessage))
                                    {
                                        logMessage.SetStatusError();
                                        logMessage.SetEndTime(time);
                                        logPoints.Add(logMessage);
                                        if (logPoints.Count >= SaveCasheSize)
                                            Flush();
                                    }
                                }
                            }
                        }
                        else
                        {

                        }
                    }
                }
                else
                {
                }
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message, e.StackTrace);
            }
        }

        public override void Close()
        {
            try
            {
                saveTimer.Enabled = false;
                Flush();
            }
            catch (Exception e)
            {
                Debug.Fail(e.Message, e.StackTrace);
            }
            finally
            {
                base.Close();
            }
        }
    }
}
