﻿namespace Logger.Loggers
{
    using System;

    using Appenders;
    using ReportLevels;

    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Info(string message)
            => Log(ReportLevel.Info, message);

        public void Warining(string message)
            => Log(ReportLevel.Warning, message);

        public void Error(string message)
            => Log(ReportLevel.Error, message);

        public void Critical(string message)
            => Log(ReportLevel.Critical, message);

        public void Fatal(string message)
            => Log(ReportLevel.Fatal, message);

        private void Log(ReportLevel level, string message)
        {
            foreach (Appender appender in Appenders)
            {
                if (level >= appender.ReportLevel)
                {
                    appender.Append(DateTime.Now, level, message);
                }
            }
        }
    }
}
