namespace Logger.LogFiles
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
