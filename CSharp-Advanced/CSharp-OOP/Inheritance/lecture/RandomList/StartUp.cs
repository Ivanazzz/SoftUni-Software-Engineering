using System;

namespace RandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Pineapple");
            list.Add("Kiwi");
            list.Add("Pear");
            list.Add("Melon");

            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.RandomString());
        }
    }
}
