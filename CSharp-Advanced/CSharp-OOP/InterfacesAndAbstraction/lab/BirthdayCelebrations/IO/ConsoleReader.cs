namespace BirthdayCelebrations.IO
{
    using System;

    using Contracts;

    internal class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
