namespace Raiding.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<BaseHero> raidGroup;

        private Engine()
        {
            raidGroup = new List<BaseHero>();
        }

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            CreateHeroesUsingFactory();

            int bossPower = int.Parse(reader.ReadLine());

            CastHeroesAbility();

            Fight(bossPower);
        }

        private void CreateHeroesUsingFactory()
        {
            int lines = int.Parse(reader.ReadLine());

            while (raidGroup.Count < lines)
            {
                try
                {
                    string heroName = reader.ReadLine();
                    string heroType = reader.ReadLine();

                    BaseHero hero = heroFactory.CreateHero(heroType, heroName);

                    raidGroup.Add(hero);
                }
                catch (InvalidHeroTypeException ihte)
                {
                    writer.WriteLine(ihte.Message);
                }
            }
        }

        private void CastHeroesAbility()
        {
            foreach (BaseHero hero in raidGroup)
            {
                writer.WriteLine(hero.CastAbility());
            }
        }

        private void Fight(int bossPower)
        {
            int totalHeroesPower = raidGroup.Sum(h => h.Power);
            string result = bossPower <= totalHeroesPower ? "Victory!" : "Defeat...";

            writer.WriteLine(result);   
        }
    }
}
