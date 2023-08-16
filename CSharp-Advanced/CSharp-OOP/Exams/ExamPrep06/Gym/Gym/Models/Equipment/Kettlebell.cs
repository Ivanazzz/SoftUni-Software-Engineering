namespace Gym.Models.Equipment
{
    public class Kettlebell : Equipment
    {
        private const int Kettlebell_WEIGHT = 10_000;
        private const int Kettlebell_PRICE = 80;

        public Kettlebell() 
            : base(Kettlebell_WEIGHT, Kettlebell_PRICE)
        {

        }
    }
}
