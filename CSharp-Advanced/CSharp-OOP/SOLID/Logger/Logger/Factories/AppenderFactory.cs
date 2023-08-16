namespace Logger.Factories
{
    using System;

    using Appenders;
    using Layouts;
    using LogFiles;
    using ReportLevels;

    public static class AppenderFactory
    {
        public static IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            IAppender appender = null;

            switch (type)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout);
                    break;
                case "FileAppender":
                    appender = new FileAppender(layout, new LogFile());
                    break;
                default:
                    throw new InvalidOperationException("Missing type");
            }

            appender.ReportLevel = reportLevel;

            return appender;
        }
    }
}
