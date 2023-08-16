namespace FoodShortage
{
    using FoodShortage.Core;
    using FoodShortage.Core.Contracts;
    using FoodShortage.IO;
    using FoodShortage.IO.Contracts;

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
