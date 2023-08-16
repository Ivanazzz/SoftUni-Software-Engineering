using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            Products = new List<Product>();
        }

        public string Name 
        { 
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameCannotBeEmpty);
                }

                name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.MoneyCannotBeNegative);
                }

                money = value;
            }
        }

        public List<Product> Products;

        public void BuyProduct(string name, string product, decimal cost)
        {
            if (cost <= Money)
            {
                Money -= cost;
                Products.Add(new Product(product, cost));
                Console.WriteLine($"{name} bought {product}");

                return;
            }

            Console.WriteLine($"{name} can't afford {product}");
        }
    }
}
