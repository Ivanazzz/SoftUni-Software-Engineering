namespace PrimeNumbersCount
{
    using System.Diagnostics;

    internal class Program
    {
        static int Count = 0;
        static object lockObj = new object();

        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread thread = new Thread(() => PrintPrimeCount(1, 2_500_000));
            thread.Start();
            Thread thread2 = new Thread(() => PrintPrimeCount(2_500_001, 5_000_000));
            thread2.Start();
            Thread thread3 = new Thread(() => PrintPrimeCount(5_000_001, 7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(() => PrintPrimeCount(7_500_001, 10_000_000));
            thread4.Start();

            thread.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);

            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        static void PrintPrimeCount(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                bool isPrime = true;

                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    // monitor
                    lock (lockObj)
                    {
                        Count++;
                    }
                }
            }
        }
    }
}