namespace Promotions.Contracts
{
    using System.Collections.Generic;
    public interface IProductDatabase
    {
        public void Save(List<Product> products);

        public List<Product> GetAll();
    }
}
