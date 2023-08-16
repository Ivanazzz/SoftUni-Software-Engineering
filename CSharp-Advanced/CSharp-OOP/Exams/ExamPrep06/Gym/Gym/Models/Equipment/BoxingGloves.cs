namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const int BOXING_GLOVES_WEIGHT = 227;
        private const int BOXING_GLOVES_PRICE = 120;

        public BoxingGloves() 
            : base(BOXING_GLOVES_WEIGHT, BOXING_GLOVES_PRICE)
        {

        }
    }
}
