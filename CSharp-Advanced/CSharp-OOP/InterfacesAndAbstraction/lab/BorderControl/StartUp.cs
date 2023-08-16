namespace BorderControl
{
    using BorderControl.Core;
    using BorderControl.Core.Contracts;
    using BorderControl.IO;
    using BorderControl.IO.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
