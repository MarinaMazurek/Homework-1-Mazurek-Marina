using System;

namespace Homework_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            bool res = int.TryParse(s, out int x);



            Fraction ex1 = new Fraction { Value1 = x, Value2 = 2 };

            Fraction ex2 = new Fraction { Value1 = 4, Value2 = 3 };

            var a = ex1 + ex2;
            Console.WriteLine($"  {a.Value1} {a.Value2}");
        }

        public class Fraction
        {
            public int Value1 { get; set; }
            public byte Value2 { get; set; }


            public static Fraction operator +(Fraction fraction1, Fraction fraction2)
            {
                return new Fraction { Value1 = fraction1.Value1 + fraction2.Value1, Value2 = (byte)(fraction1.Value2 + fraction2.Value2) };
            }

        }
    }
}

