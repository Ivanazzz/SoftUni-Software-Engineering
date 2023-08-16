namespace Logger.Appenders
{
    using System;

    using Layouts;
    using ReportLevels;

    public abstract class Appender : IAppender
    {
        public Appender(ILayout layuot)
        {
            Layout = layuot;
        }

        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }

        public int AppendedMessages { get; protected set; }

        public abstract void Append(DateTime dateTime, ReportLevel reportLevel, string message);

        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {AppendedMessages}";
    }
}
