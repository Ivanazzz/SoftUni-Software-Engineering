namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int PLANT_COMFORT_VALUE = 5;
        private const decimal PLANT_PRICE_VALUE = 10;

        public Plant()
            : base(PLANT_COMFORT_VALUE, PLANT_PRICE_VALUE)
        {

        }
    }
}
