using System;
using System.Text;

namespace Robot.Utilities.Logs
{
    /// <summary>
    /// StringBuilder Logger class to log message to StringBuilder
    /// </summary>
    public class StringBuilderLogger : ILogger
    {
        public StringBuilder Logs;

        public StringBuilderLogger()
        {
            Logs = new StringBuilder();
        }

        public void Log(string message)
        {
            Logs.AppendFormat("{0}", message);
            Logs.Append(Environment.NewLine);
        }

        public override string ToString()
        {
            return Logs.ToString();
        }
    }
}
