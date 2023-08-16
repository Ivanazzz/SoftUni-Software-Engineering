using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> firstScale = new EqualityScale<int>(3, 5);
            EqualityScale<int> secondScale = new EqualityScale<int>(5, 5);

            Console.WriteLine(firstScale.AreEqual());
            Console.WriteLine(secondScale.AreEqual());
        }
    }
}
