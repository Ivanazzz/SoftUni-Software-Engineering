﻿namespace Logger
{
    using System;
    using System.Collections.Generic;

    using Appenders;
    using Factories;
    using Layouts;
    using ReportLevels;
    using Loggers;

    public class Program
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            List<IAppender> appenders = new List<IAppender>();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderType = Console.ReadLine()
                    .Split();

                string type = appenderType[0];
                string layoutType = appenderType[1];
                ReportLevel reportLevel = appenderType.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderType[2], true)
                    : ReportLevel.Info;


                ILayout layout = LayoutFactory.CreateLayout(layoutType);
                IAppender appender = AppenderFactory.CreateAppender(type, layout, reportLevel);

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders.ToArray());

            string command;
            while ((command = Console.ReadLine()) != "END")
            {   
                string[] messageInfo = command.Split('|');

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(messageInfo[0], true);  
                DateTime dateTime = DateTime.Parse(messageInfo[1]);
                string message = messageInfo[2];

                switch (reportLevel)
                {
                    case ReportLevel.Fatal:
                        logger.Fatal(message);
                        break;
                    case ReportLevel.Critical:
                        logger.Critical(message);
                        break;
                    case ReportLevel.Error:
                        logger.Error(message);
                        break;
                    case ReportLevel.Warning:
                        logger.Warining(message);
                        break;
                    case ReportLevel.Info:
                        logger.Info(message);
                        break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in logger.Appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}
