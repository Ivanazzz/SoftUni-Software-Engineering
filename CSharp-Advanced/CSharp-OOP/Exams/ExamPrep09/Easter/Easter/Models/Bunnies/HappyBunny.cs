namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HAPPY_BUNNY_ENERGY = 100;

        public HappyBunny(string name) 
            : base(name, HAPPY_BUNNY_ENERGY)
        {

        }
    }
}
