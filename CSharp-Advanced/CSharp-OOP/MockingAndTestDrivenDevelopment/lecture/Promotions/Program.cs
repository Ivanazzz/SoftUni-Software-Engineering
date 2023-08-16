namespace Promotions
{
    using System.Collections.Generic;

    using Promotions.Contracts;

    internal class Program
    {
        static void Main(string[] args)
        {
            IProductDatabase database = new TextProductDatabase();

            List<Product> products = new List<Product>()
            {
                new Product(1, "Bread", 2),
                new Product(2, "Chocolate", 8),
                new Product(3, "Milk", 1),
            };

            database.Save(products);

            //ProductsService service = new ProductsService(database);

            //foreach (Product product in service.GetAllProductsForToday())
            //{
            //    Console.WriteLine(product);
            //}
        }
    }
}
