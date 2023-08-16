namespace SpaceStation.Models.Mission
{
    using System.Collections.Generic;
    using System.Linq;

    using Astronauts.Contracts;
    using Contracts;
    using Planets.Contracts;

    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut astronaut in astronauts.Where(a => a.CanBreath))
            {
                for (int i = 0; i < planet.Items.Count; i++)
                {
                    string item = planet.Items.ElementAt(0);

                    if (astronaut.CanBreath)
                    {
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        i--;
                    }
                }

                if (!planet.Items.Any())
                {
                    break;
                }
            }
        }
    }
}
