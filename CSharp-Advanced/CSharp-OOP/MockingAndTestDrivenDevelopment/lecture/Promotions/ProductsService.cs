namespace Promotions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Promotions.Contracts;

    public class ProductsService : IPromotionService
    {
        private IProductDatabase productsDatabase;
        private List<Product> products;
        private IPromotionService promotionService;

        public ProductsService(IProductDatabase db, IPromotionService promotionsService)
        {
            this.productsDatabase = db;
            this.promotionService = promotionsService;

            Products = db.GetAll();
        }

        public List<Product> Products { get { return products; } set { products = value; } }

        public void Add(Product product)
        {
            products.Add(product);

            productsDatabase.Save(products);
        }

        public void Delete(int id)
        {
            Product product = FindById(id);

            if (product == null)
            {
                throw new ArgumentException("Product not found!");
            }

            products.Remove(product);

            productsDatabase.Save(products);
        }

        public List<Product> GetAllProductsForToday()
        {
            List<Product> productsWithPromotionsApplied = new List<Product>();

            foreach (Product product in Products)
            {
                decimal price = promotionService.GetPromotion(product);

                productsWithPromotionsApplied.Add(new Product(product.Id, product.Name, price));
            }

            return productsWithPromotionsApplied;
        }

        public decimal GetPromotion(Product product)
        {
            throw new NotImplementedException();
        }

        private Product FindById(int id)
            => Products.FirstOrDefault(p => p.Id == id);
    }
}
