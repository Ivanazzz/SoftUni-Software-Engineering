namespace Promotions
{
    using System;

    public class PromotionService
    {
        private DateTime dateToday;

        public PromotionService(DateTime dateToday)
        {
            this.dateToday = dateToday;
        }

        public decimal GetPromotion(Product product)
        {
            decimal percentage = 0;

            if (dateToday.DayOfWeek == DayOfWeek.Monday)
            {
                percentage = 10;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Tuesday)
            {
                percentage = 20;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Wednesday)
            {
                percentage = 35;
            }
            else if (dateToday.DayOfWeek == DayOfWeek.Sunday)
            {
                percentage = 80;
            }

            return product.Price - (percentage / 100 * product.Price);
        }
    }
}
