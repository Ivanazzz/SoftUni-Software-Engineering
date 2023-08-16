using System;
using System.Text.RegularExpressions;

namespace SoftUniBarIncome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<quantity>[\d]+)\|[^|$%.]*?(?<price>[\d]+.?[\d]+)?\$";

            double totalIncome = 0;

            string input = Console.ReadLine();
            while (input != "end of shift")
            {
                Regex regex = new Regex(pattern);
                bool isValid = regex.IsMatch(input);

                if (isValid)
                {
                    string customer = regex.Match(input).Groups["customer"].Value;
                    string product = regex.Match(input).Groups["product"].Value;
                    int quantity = int.Parse(regex.Match(input).Groups["quantity"].Value);
                    double price = double.Parse(regex.Match(input).Groups["price"].Value);

                    double totalPriceForCurrentProduct = quantity * price;
                    totalIncome += totalPriceForCurrentProduct;
                    Console.WriteLine($"{customer}: {product} - {totalPriceForCurrentProduct:f2}");
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
