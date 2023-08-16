//namespace Promotions.Test
//{
//    using System.Linq;

//    using NUnit.Framework;
//    using Promotions.Test.Fakes;

//    public class ProductsServiceTestsWithFakes
//    {
//        private ProductsService service;
//        private DummyProductsDatabase dummyDb;

//        [SetUp]
//        public void SetUp()
//        {
//            dummyDb = new DummyProductsDatabase();
//            service = new ProductsService(dummyDb);
//        }

//        [Test]
//        public void AddProduct()
//        {
//            service.Add(new Product(1, "TestProduct", 5));

//            Assert.AreEqual(4, service.Products.Count);
//            Assert.AreEqual(1, dummyDb.SaveCallTimes);
//        }

//        [Test]
//        public void AddMultipleProducts()
//        {
//            service.Add(new Product(1, "TestProduct1", 5));
//            service.Add(new Product(2, "TestProduc2", 6));
//            service.Add(new Product(3, "TestProduct3", 7));
//            service.Add(new Product(4, "TestProduct4", 8));

//            Assert.AreEqual(7, service.Products.Count);
//            Assert.AreEqual(4, dummyDb.SaveCallTimes);
//        }

//        [Test]
//        public void DeleteProduct()
//        {
//            service.Add(new Product(4, "TestProduct", 15));

//            service.Delete(4);

//            Assert.AreEqual(3, service.Products.Count);
//            Assert.AreEqual(false, service.Products.Any(x => x.Id == 4));
//            Assert.AreEqual(2, dummyDb.SaveCallTimes);
//        }
//    }
//}
