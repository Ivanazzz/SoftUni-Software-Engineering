namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SLEEPY_BUNNY_ENERGY = 50;
        private const int SLEEPY_BUNNY_ENERGY_DECREASE_VALUE = 15;

        public SleepyBunny(string name) 
            : base(name, SLEEPY_BUNNY_ENERGY)
        {

        }

        public override void Work()
            => Energy -= SLEEPY_BUNNY_ENERGY_DECREASE_VALUE;
    }
}
