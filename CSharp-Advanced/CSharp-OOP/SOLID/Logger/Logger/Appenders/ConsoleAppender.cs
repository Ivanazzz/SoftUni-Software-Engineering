namespace Logger.Appenders
{
    using System;

    using Layouts;
    using ReportLevels;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layuot) 
            : base(layuot)
        {
        }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string output = string.Format(Layout.Format, dateTime, reportLevel, message);

            AppendedMessages++;

            Console.WriteLine(output);
        }
    }
}
