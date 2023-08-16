using System;

namespace MultiplicationTable2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int integer = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());

            do
            {
                Console.WriteLine($"{integer} X {times} = {integer * times}");
                times++;
            } while (times <= 10);
        }
    }
}
