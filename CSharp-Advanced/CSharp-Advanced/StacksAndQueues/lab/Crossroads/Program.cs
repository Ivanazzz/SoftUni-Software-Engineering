using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDurationInSeconds = int.Parse(Console.ReadLine());
            int freeWindowDurationInSeconds = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int totalCarsPassed = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                GreenLight(greenLightDurationInSeconds, ref freeWindowDurationInSeconds, cars, ref totalCarsPassed, command);

                command = Console.ReadLine();
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }

        private static void GreenLight(int greenLightDurationInSeconds, ref int freeWindowDurationInSeconds, Queue<string> cars, ref int totalCarsPassed, string command)
        {
            if (command == "green")
            {
                int currentGreenLightDuration = greenLightDurationInSeconds;

                while (currentGreenLightDuration > 0 && cars.Any())
                {
                    int currentCarToPassLength = cars.Peek().Length;
                    string currentCar = cars.Peek();

                    if (currentGreenLightDuration >= currentCarToPassLength)
                    {
                        cars.Dequeue();
                        totalCarsPassed++;
                        currentGreenLightDuration -= currentCarToPassLength;
                    }
                    else
                    {
                        int totalSecondsToPass = currentGreenLightDuration + freeWindowDurationInSeconds;

                        if (totalSecondsToPass >= currentCarToPassLength)
                        {
                            cars.Dequeue();
                            totalCarsPassed++;
                            freeWindowDurationInSeconds -= currentCarToPassLength - currentGreenLightDuration;
                            currentGreenLightDuration = 0;
                        }
                        else
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{currentCar} was hit at {currentCar[totalSecondsToPass]}.");
                            Environment.Exit(0);
                        }
                    }
                }
            }
            else
            {
                cars.Enqueue(command);
            }
        }
    }
}
