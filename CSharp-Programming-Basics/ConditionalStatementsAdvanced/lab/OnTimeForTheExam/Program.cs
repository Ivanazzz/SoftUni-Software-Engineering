using System;

namespace OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMin = int.Parse(Console.ReadLine());

            examMin = examMin + examHour * 60;
            arrivalMin = arrivalMin + arrivalHour * 60;

            int difference = 0;
            int diffHour = 0;
            int diffMin = 0;

            if (examMin < arrivalMin)
            {
                Console.WriteLine("Late");
                difference = arrivalMin - examMin;
                diffHour = difference / 60;
                diffMin = difference % 60;

                if (diffHour >= 1)
                {
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours after the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes after the start");
                }
            }
            else if (examMin - arrivalMin <= 30)
            {
                Console.WriteLine("On time");

                if (examMin != arrivalMin)
                {
                    difference = examMin - arrivalMin;
                    Console.WriteLine($"{difference} minutes before the start");
                }
            }
            else if (examMin - arrivalMin > 30)
            {
                Console.WriteLine("Early");
                difference = examMin - arrivalMin;
                diffHour = difference / 60;
                diffMin = difference % 60;

                if (diffHour >= 1)
                {
                    if (diffMin < 10)
                    {
                        Console.WriteLine($"{diffHour}:0{diffMin} hours before the start");
                    }
                    else
                    {
                        Console.WriteLine($"{diffHour}:{diffMin} hours before the start");
                    }
                }
                else
                {
                    Console.WriteLine($"{diffMin} minutes before the start");
                }
            }
        }
    }
}
