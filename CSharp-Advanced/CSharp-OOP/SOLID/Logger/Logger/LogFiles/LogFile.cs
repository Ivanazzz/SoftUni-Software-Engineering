namespace Logger.LogFiles
{
    using System.Linq;
    using System.Text;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder stringBuilder;

        public LogFile()
        {
            stringBuilder = new StringBuilder();
        }

        public int Size
            => stringBuilder
            .ToString()
            .Where(char.IsLetter)
            .Sum(x => x);

        public void Write(string message)
            => stringBuilder.AppendLine(message);
    }
}
