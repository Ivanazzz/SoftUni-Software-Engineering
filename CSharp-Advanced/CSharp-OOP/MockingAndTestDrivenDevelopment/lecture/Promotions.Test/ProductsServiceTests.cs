namespace Promotions.Test
{
    using System.Collections.Generic;
    using System.Linq;

    using Moq;
    using NUnit.Framework;
    using Promotions.Contracts;

    public class ProductsServiceTests
    {
        private ProductsService service;
        private Mock<IProductDatabase> mockDb;
        private Mock<IPromotionService> mockPromotions;

        [SetUp]
        public void SetUp()
        {
            mockDb = new Mock<IProductDatabase>();
            mockPromotions = new Mock<IPromotionService>();

            mockDb.Setup(db => db.GetAll()).Returns(new List<Product>());
            service = new ProductsService(mockDb.Object, mockPromotions.Object);
        }

        [Test]
        public void AddProduct()
        {
            service.Add(new Product(1, "TestProduct", 5));

            Assert.AreEqual(1, service.Products.Count);
            mockDb.Verify(db => db.Save(It.IsAny<List<Product>>()), Times.Once);
        }

        [Test]
        public void AddMultipleProducts()
        {
            service.Add(new Product(1, "TestProduct1", 5));
            service.Add(new Product(2, "TestProduc2", 6));
            service.Add(new Product(3, "TestProduct3", 7));
            service.Add(new Product(4, "TestProduct4", 8));

            Assert.AreEqual(4, service.Products.Count);
            mockDb.Verify(db => db.Save(It.IsAny<List<Product>>()), Times.Exactly(4));
        }

        [Test]
        public void DeleteProduct()
        {
            service.Add(new Product(4, "TestProduct", 15));

            service.Delete(4);

            Assert.AreEqual(0, service.Products.Count);
            Assert.AreEqual(false, service.Products.Any(x => x.Id == 4));
        }

        [Test]
        public void GetAllProductsShouldSetPromotionCorrectly()
        {
            service.Add(new Product(4, "TestProduct", 100));
            mockPromotions.Setup(pr => pr.GetPromotion(It.IsAny<Product>()))
                .Returns(20);

            List<Product> products = service.GetAllProductsForToday();

            Assert.AreEqual(20, products[0].Price);
        }
    }
}
