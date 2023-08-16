namespace PlayCatch
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private const int MAX_NUMBER_OF_EXCEPTIONS = 3;

        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int numberOfExceptions = 0;

            while (numberOfExceptions < MAX_NUMBER_OF_EXCEPTIONS)
            {
                string[] cmdTokens = Console.ReadLine()
                    .Split(' ');
                string cmdType = cmdTokens[0];

                try
                {
                    switch (cmdType)
                    {
                        case "Replace":
                            int indexOfReplacement = 0;
                            int elementForReplacement = 0;

                            bool isIndex = int.TryParse(cmdTokens[1], out indexOfReplacement);
                            bool isNumber = int.TryParse(cmdTokens[2], out elementForReplacement);

                            if (!isIndex || !isNumber)
                            {
                                throw new FormatException("The variable is not in the correct format!");
                            }

                            if (indexOfReplacement < 0 || indexOfReplacement >= elements.Length)
                            {
                                throw new InvalidOperationException("The index does not exist!");
                            }

                            elements[indexOfReplacement] = elementForReplacement;
                            break;
                        case "Print":
                            int startIndex = 0;
                            int endIndex = 0;

                            bool isStartIndexNumber = int.TryParse(cmdTokens[1], out startIndex);
                            bool isEndIndexNumber = int.TryParse(cmdTokens[2], out endIndex);

                            if (!isStartIndexNumber || !isEndIndexNumber)
                            {
                                throw new FormatException("The variable is not in the correct format!");
                            }

                            if (startIndex < 0 || startIndex >= elements.Length ||
                                endIndex < 0 || endIndex >= elements.Length ||
                                endIndex < startIndex)
                            {
                                throw new InvalidOperationException("The index does not exist!");
                            }

                            int[] elementsToPrint = elements
                                .Skip(startIndex)
                                .Take(endIndex - startIndex + 1)
                                .ToArray();

                            Console.WriteLine(string.Join(", ", elementsToPrint));
                            break;
                        case "Show":
                            int index = 0;
                            if (!int.TryParse(cmdTokens[1], out index))
                            {
                                throw new FormatException("The variable is not in the correct format!");
                            }

                            if (index < 0 || index >= elements.Length)
                            {
                                throw new InvalidOperationException("The index does not exist!");
                            }

                            Console.WriteLine(elements[index]);
                            break;
                    }
                }
                catch (FormatException fe)
                {
                    numberOfExceptions++;
                    Console.WriteLine(fe.Message);
                }
                catch (InvalidOperationException ioe)
                {
                    numberOfExceptions++;
                    Console.WriteLine(ioe.Message);
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
