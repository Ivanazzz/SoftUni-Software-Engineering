﻿namespace Formula1.IO
{
    using System;

    using Contracts;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
