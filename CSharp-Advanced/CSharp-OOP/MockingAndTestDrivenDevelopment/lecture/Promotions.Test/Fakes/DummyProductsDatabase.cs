namespace Promotions.Test.Fakes
{
    using System.Collections.Generic;

    using Promotions.Contracts;

    public class DummyProductsDatabase : IProductDatabase
    {
        public List<Product> GetAll()
        {
            return new List<Product>()
            {
                new Product(1, "1", 5),
                new Product(2, "2", 6),
                new Product(3, "3", 7),
            };
        }

        public void Save(List<Product> products)
        {
            SaveCallTimes++;
        }

        public int SaveCallTimes { get; set; }
    }
}
