using System;

namespace HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string header = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {header}");
            Console.WriteLine("</h1>");

            string article = Console.ReadLine();
            Console.WriteLine("<article>");
            Console.WriteLine($"    {article}");
            Console.WriteLine("</article>");

            while (true)
            {
                string div = Console.ReadLine();
                if (div == "end of comments")
                {
                    break;
                }

                Console.WriteLine("<div>");
                Console.WriteLine($"    {div}");
                Console.WriteLine("</div>");
            }
        }
    }
}
