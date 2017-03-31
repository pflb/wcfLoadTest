using System.Collections.Generic;

namespace PFLB
{
    class LogPoints
    {
        List<LogMessage> messages = new List<LogMessage>();

        public int Count { get { lock (this) { return messages.Count; } } }

        public void Add(LogMessage message)
        {
            lock (this)
            {
                messages.Add(message);
            }
        }

        public LogMessage[] Flush()
        {
            lock (this)
            {
                LogMessage[] result = new LogMessage[messages.Count];
                messages.CopyTo(result);
                messages.Clear();
                return result;
            }
        }
    }
}
