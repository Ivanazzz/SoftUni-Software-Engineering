using System;

namespace AluminumJoinery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int joineryCount = int.Parse(Console.ReadLine());
            string joineryType = Console.ReadLine();
            string delivery = Console.ReadLine();

            if (joineryCount < 10)
            {
                Console.WriteLine("Invalid order");
                return;
            }

            double price = 0;

            switch (joineryType)
            {
                case "90X130":
                    price = joineryCount * 110;
                    if (joineryCount > 60)
                    {
                        price -= price * 0.08;
                    }
                    else if (joineryCount > 30)
                    {
                        price -= price * 0.05;
                    }
                    break;
                case "100X150":
                    price = joineryCount * 140;
                    if (joineryCount > 80)
                    {
                        price -= price * 0.1;
                    }
                    else if (joineryCount > 40)
                    {
                        price -= price * 0.06;
                    }
                    break;
                case "130X180":
                    price = joineryCount * 190;
                    if (joineryCount > 50)
                    {
                        price -= price * 0.12;
                    }
                    else if (joineryCount > 20)
                    {
                        price -= price * 0.07;
                    }
                    break;
                case "200X300":
                    price = joineryCount * 250;
                    if (joineryCount > 50)
                    {
                        price -= price * 0.14;
                    }
                    else if (joineryCount > 25)
                    {
                        price -= price * 0.09;
                    }
                    break;
            }

            if (delivery == "With delivery")
            {
                price += 60;
            }

            if (joineryCount > 99)
            {
                price -= price * 0.04;
            }

            Console.WriteLine($"{price:F2} BGN");
        }
    }
}
