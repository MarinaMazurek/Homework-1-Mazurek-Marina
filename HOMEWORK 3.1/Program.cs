using System;

namespace HOMEWORK_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First number:");
            int x1 = EnterIntegerPartOfNumber();
            byte y1 = EnterFractionalPartOfNumber();

            Console.WriteLine("\nSecond number:");
            int x2 = EnterIntegerPartOfNumber();
            byte y2 = EnterFractionalPartOfNumber();

            Fraction ex1 = new Fraction { Value1 = x1, Value2 = y1 };
            Fraction ex2 = new Fraction { Value1 = x2, Value2 = y2 };

            var sum = ex1 + ex2;
            Console.WriteLine($"Sym of two numbers: {sum.Value1},{sum.Value2}");

            var subtraction = ex1 - ex2;
            Console.WriteLine($"Subtraction of two numbers: {subtraction.Value1},{subtraction.Value2}");

            bool comparison1 = ex1 > ex2;
            bool comparison2 = ex1 < ex2;

            if (comparison1 == true)
            {
                Console.WriteLine($"First number {ex1.Value1},{ex1.Value2} more than second number {ex2.Value1},{ex2.Value2}");
            }
            else if (comparison2 == true)
            {
                Console.WriteLine($"First number {ex1.Value1},{ex1.Value2} less than second number {ex2.Value1},{ex2.Value2}");
            }

            bool comparison3 = ex1.Value1 == ex2.Value1 && ex1.Value2 == ex2.Value2;
            if (comparison3 == true)
            {
                Console.WriteLine($"First number {ex1.Value1},{ex1.Value2} equals second number {ex2.Value1},{ex2.Value2}");
            }

            Console.ReadKey();
        }

        static int EnterIntegerPartOfNumber()
        {
            Console.WriteLine("Enter integer part of the number");
            string s = Console.ReadLine();
            bool res1 = int.TryParse(s, out int x);
            return x;
        }

        static byte EnterFractionalPartOfNumber()
        {
            Console.WriteLine("Enter fractional part of the second number");
            string s = Console.ReadLine();
            bool res = byte.TryParse(s, out byte y);
            return y;
        }        
    }
}
