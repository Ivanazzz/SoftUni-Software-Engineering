using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";

            int countOfBarcodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfBarcodes; i++)
            {
                string barcode = Console.ReadLine();

                if (Regex.IsMatch(barcode, pattern))
                {
                    char[] digits = barcode.Where(char.IsDigit).ToArray();
                    string barcodeGroup = digits.Length == 0 ? "00" : string.Join("", digits);
                    Console.WriteLine($"Product group: {barcodeGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
