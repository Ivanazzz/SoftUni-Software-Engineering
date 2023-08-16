namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const int INITIAL_BIOLOGIST_OXYGEN = 70;
        private const int NEEDED_OXYGEN_FOR_BREATHING = 5;

        public Biologist(string name) 
            : base(name, INITIAL_BIOLOGIST_OXYGEN)
        {

        }

        public override void Breath()
        {
            if (Oxygen >= NEEDED_OXYGEN_FOR_BREATHING)
            {
                Oxygen -= NEEDED_OXYGEN_FOR_BREATHING;
            }
        }
    }
}
