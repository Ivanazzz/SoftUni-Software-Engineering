namespace Raiding.Factories
{
    using Exceptions;
    using Factories.Contracts;
    using Models;

    public class HeroFactory : IHeroFactory
    {
        public HeroFactory()
        {

        }

        public BaseHero CreateHero(string type, string name)
        {
            BaseHero hero;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroTypeException();
            }

            return hero;
        }
    }
}
