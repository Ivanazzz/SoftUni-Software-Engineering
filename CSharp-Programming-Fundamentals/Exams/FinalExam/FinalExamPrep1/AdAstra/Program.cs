using System;
using System.Text.RegularExpressions;

namespace AdAstra
{
    internal class Program
    {
        public const int NeededKcalPerDay = 2000;
        static void Main(string[] args)
        {
            string pattern = @"(?<chr>[|#])(?<foodName>[A-Za-z\s]+)(\k<chr>)(?<date>\d{2}\/\d{2}\/\d{2})(\k<chr>)(?<calories>\d+)(\k<chr>)";

            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            MatchCollection matchedFood = regex.Matches(input);

            int totalKcalories = 0;

            foreach (Match match in matchedFood)
            {
                totalKcalories += int.Parse(match.Groups["calories"].Value);
            }

            int numberOfDaysWithEnoughFood = totalKcalories / NeededKcalPerDay;

            Console.WriteLine($"You have food to last you for: {numberOfDaysWithEnoughFood} days!");
            foreach (Match match in matchedFood)
            {
                Console.WriteLine($"Item: {match.Groups["foodName"].Value}, Best before: {match.Groups["date"].Value}, Nutrition: {match.Groups["calories"].Value}");
            }
        }
    }
}
