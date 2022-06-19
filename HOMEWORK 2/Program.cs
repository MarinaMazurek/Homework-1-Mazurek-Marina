using System;

namespace HOMEWORK_2
{
    class Program
    {
        const string SYMBOL_FOR_CONTINUE = "Y";
        const int MAX_VALUE_FOR_RANDOM = 100;
        const int MIN_VALUE_FOR_RANDOM = -100;

        static void Main(string[] args)
        {
            bool isContinue;

            do
            {
                SelectOperation();

                Console.WriteLine(" \n" + "Do you want continue? Y/N");
                isContinue = Console.ReadLine().ToUpperInvariant() == SYMBOL_FOR_CONTINUE;
                Console.WriteLine();
            }
            while (isContinue);
        }

        static void SelectOperation()
        {
            Console.WriteLine("Select operation:\n" +
                                "1 - Addition \n" +
                                "2 - Subtraction \n" +
                                "3 - Multiplication \n" +
                                "4 - Division \n" +
                                "5 - Exponentiation \n" +
                                "6 - Factorial \n" +
                                "0 - Exit \n");

            var selectedBlock = Console.ReadLine();

            if (int.TryParse(selectedBlock, out int option))
            {
                switch (option)
                {
                    case 1:
                        SumNumbers();
                        break;
                    case 2:
                        SubtractNumbers();
                        break;
                    case 3:
                        MultiplyNumbers();
                        break;
                    case 4:
                        DivideNumbers();
                        break;
                    case 5:
                        ExponentiateNumbers();
                        break;
                    case 6:
                        long check = GetNumberForFactorial();
                        Console.WriteLine($"Result of factorial: {Factorial(check)}");
                        break;
                    case 0:
                        return;
                    default:
                        ProcessIncorrectInput();
                        break;
                }
            }
            else
            {
                ProcessIncorrectInput();
            }
        }

        static double CreateRandom()
        {
            Random rnd = new Random();
            double randValue = rnd.Next(MIN_VALUE_FOR_RANDOM, MAX_VALUE_FOR_RANDOM);

            return randValue;
        }

        static void SumNumbers()
        {
            double randValueFirst = CreateRandom();
            Console.WriteLine($"First number: {randValueFirst}");

            double randValueSecond = CreateRandom();
            Console.WriteLine($"Second number: {randValueSecond}");

            double result = randValueFirst + randValueSecond;
            Console.WriteLine($"Result of sum: {result}");
        }

        static void SubtractNumbers()
        {
            Console.Write($"Enter minuend: ");
            var isMinuendInt = double.TryParse(Console.ReadLine(), out double minuend);

            Console.Write("Enter subtrahend: ");
            var isSubtrahendInt = double.TryParse(Console.ReadLine(), out double subtrahend);

            if (!isMinuendInt || !isSubtrahendInt)
            {
                ProcessIncorrectInput();
            }

            var difference = minuend - subtrahend;
            Console.WriteLine($"Result of difference: {difference}"); //разность                       
        }

        static void MultiplyNumbers()
        {
            var randValueForFirstMultiplier = CreateRandom();
            Console.WriteLine($"First multiplier = {randValueForFirstMultiplier}");

            var randValueForSecondMultiplier = CreateRandom();
            Console.WriteLine($"Second multiplier = {randValueForSecondMultiplier}");

            var result = randValueForFirstMultiplier * randValueForSecondMultiplier;
            Console.WriteLine($"Result of multiplication: {result}");
        }

        static void DivideNumbers()
        {
            var randValueForDividend = CreateRandom();
            Console.WriteLine($"Dividend = {randValueForDividend}");

            var randValueForDivider = CreateRandom();
            Console.WriteLine($"Divider = {randValueForDivider}");

            var result = randValueForDividend / randValueForDivider;
            Console.WriteLine($"Result of division: {result}");
        }

        static void ExponentiateNumbers()
        {
            var randValueForNumber = CreateRandom();
            Console.WriteLine($"Number raised to a degree = {randValueForNumber}");

            var randValueForDegree = CreateRandom();
            Console.WriteLine($"Degree = {randValueForDegree}");

            var result = Math.Pow(randValueForNumber, randValueForDegree);
            Console.WriteLine($"Result of exponentiation: {result}");
        }

        static long Factorial(long n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }

        }

        static long GetNumberForFactorial()
        {
            Console.Write($"Enter number to calculate factorial: ");
            var isInt = long.TryParse(Console.ReadLine(), out long n);
            if (!isInt || n <= 0)
            {
                ProcessIncorrectInput();
            }

            return n;
        }

        static void ProcessIncorrectInput()
        {
            Console.WriteLine("Incorrect Input");
            Console.WriteLine();
            SelectOperation();
        }
    }
}
