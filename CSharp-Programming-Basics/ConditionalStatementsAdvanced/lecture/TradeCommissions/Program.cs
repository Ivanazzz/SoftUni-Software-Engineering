using System;

namespace TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double percent = 0;

            switch (city)
            {
                case "Sofia":
                    if (sales > 10000)
                    {
                        percent = 0.12;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        percent = 0.08;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        percent = 0.07;
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        percent = 0.05;
                    }
                    break;
                case "Varna":
                    if (sales > 10000)
                    {
                        percent = 0.13;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        percent = 0.10;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        percent = 0.075;
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        percent = 0.045;
                    }
                    break;
                case "Plovdiv":
                    if (sales > 10000)
                    {
                        percent = 0.145;
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        percent = 0.12;
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        percent = 0.08;
                    }
                    else if (sales > 0 && sales <= 500)
                    {
                        percent = 0.055;
                    }
                    break;
            }

            double commission = sales * percent;

            if (commission > 0)
            {
                Console.WriteLine($"{commission:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }
        }
    }
}
