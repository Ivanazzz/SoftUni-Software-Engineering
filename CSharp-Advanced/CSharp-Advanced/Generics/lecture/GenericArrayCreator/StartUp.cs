using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] numbers = ArrayCreator.Create(10, 42);
            Console.WriteLine(string.Join(' ', numbers));

            string[] strings = ArrayCreator.Create(5, "Ivan");
            Console.WriteLine(string.Join(' ', strings));
        }
    }
}
