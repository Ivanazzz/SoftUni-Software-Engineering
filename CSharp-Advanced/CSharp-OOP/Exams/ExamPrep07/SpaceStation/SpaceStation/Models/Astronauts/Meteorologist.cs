namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const int INITIAL_METEOROLOGIST_OXYGEN = 90;

        public Meteorologist(string name)
            : base(name, INITIAL_METEOROLOGIST_OXYGEN)
        {

        }
    }
}
