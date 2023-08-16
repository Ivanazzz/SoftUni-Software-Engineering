namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int ORNAMENT_COMFORT_VALUE = 1;
        private const decimal ORNAMENT_PRICE_VALUE = 5;

        public Ornament() 
            : base(ORNAMENT_COMFORT_VALUE, ORNAMENT_PRICE_VALUE)
        {

        }
    }
}
