namespace SumOfIntegers
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine()
                .Split(' ');

            int sum = 0;

            foreach (string element in elements)
            {
                try
                {
                    long number = 0;
                    bool IsNumber = long.TryParse(element, out number);
                    if (!IsNumber)
                    {
                        throw new FormatException($"The element '{element}' is in wrong format!");
                    }
                    if (number > Int32.MaxValue || number < Int32.MinValue)
                    {
                        throw new OverflowException($"The element '{element}' is out of range!");
                    }

                    int numberAsInt = Convert.ToInt32(number);
                    sum += numberAsInt;
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine(oe.Message);
                }
                finally
                {
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
