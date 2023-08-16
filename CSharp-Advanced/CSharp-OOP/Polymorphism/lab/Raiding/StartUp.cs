namespace Raiding
{
    using Core;
    using Factories;
    using Factories.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);
            engine.Run();
        }
    }
}
