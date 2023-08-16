namespace Logger.Appenders
{
    using System;
    using System.IO;

    using Layouts;
    using LogFiles;
    using ReportLevels;

    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layuot, ILogFile logFile) 
            : base(layuot)
        {
            this.logFile = logFile;
        }

        public override void Append(DateTime dateTime, ReportLevel reportLevel, string message)
        {
            string output = string.Format(Layout.Format, dateTime, reportLevel, message) + Environment.NewLine;

            logFile.Write(output);

            AppendedMessages++;

            File.AppendAllText("../../../log.txt", output);
        }

        public override string ToString()
            => base.ToString() + $", File size: {logFile.Size}";
    }
}
