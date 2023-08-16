using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] peopleInput = Console.ReadLine()
                .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < peopleInput.Length; i++)
                {
                    string[] personTokens = peopleInput[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    people.Add(new Person(personTokens[0], decimal.Parse(personTokens[1])));
                }

                string[] productInput = Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInput.Length; i++)
                {
                    string[] productTokens = productInput[i]
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);

                    products.Add(new Product(productTokens[0], decimal.Parse(productTokens[1])));
                }

                while (true)
                {
                    string[] input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    if (input[0] == "END")
                    {
                        break;
                    }

                    string name = input[0];
                    string product = input[1];

                    Person currentPerson = people.FirstOrDefault(p => p.Name == name);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == product);

                    if (currentPerson != null && currentProduct != null)
                    {
                        currentPerson.BuyProduct(name, currentProduct.Name, currentProduct.Cost);
                    }
                }

                foreach (Person person in people)
                {
                    if (person.Products.Any())
                    {
                        Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products.Select(p => p.Name))}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
