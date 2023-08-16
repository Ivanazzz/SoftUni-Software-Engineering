using System;

namespace ActivationKeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rawActivationKey = Console.ReadLine();

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0] == "Generate")
                {
                    break;
                }

                string action = tokens[0];

                switch (action)
                {
                    case "Contains":
                        Contains(rawActivationKey, tokens[1]);
                        break;
                    case "Flip":
                        rawActivationKey = Flip(rawActivationKey, tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]));
                        break;
                    case "Slice":
                        rawActivationKey = Slice(rawActivationKey, int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }

        private static void Contains(string rawActivationKey, string substring)
        {
            if (rawActivationKey.Contains(substring))
            {
                Console.WriteLine($"{rawActivationKey} contains {substring}");
            }
            else
            {
                Console.WriteLine("Substring not found!");
            }
        }

        private static string Flip(string rawActivationKey, string upperOrLower, int startIndex, int endIndex)
        {
            string originalSubstring = rawActivationKey.Substring(startIndex, endIndex - startIndex);
            string newSubstring = originalSubstring.ToLower();

            if (upperOrLower == "Upper")
            {
                newSubstring = newSubstring.ToUpper();
;           }

            rawActivationKey = rawActivationKey.Replace(originalSubstring, newSubstring);
            Console.WriteLine(rawActivationKey);

            return rawActivationKey;
;        }

        private static string Slice(string rawActivationKey, int startIndex, int endIndex)
        {
            rawActivationKey = rawActivationKey.Remove(startIndex, endIndex - startIndex);
            Console.WriteLine(rawActivationKey);

            return rawActivationKey;
        }
    }
}
