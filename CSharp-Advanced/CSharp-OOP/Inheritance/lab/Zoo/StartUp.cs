using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Snake snake = new Snake("Jim");
            Console.WriteLine(snake.Name);
        }
    }
}
