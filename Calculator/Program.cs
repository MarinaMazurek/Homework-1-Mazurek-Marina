using System;

namespace Calculator
{
    class Program
    {
        //($"{number}*N={number * N}");

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number for show multiplication table:");
            var userInput = Console.ReadLine();

            var isNumber = int.TryParse(userInput, out int number);


            Console.WriteLine("Enter number of multiplication order:");
            var isInt = Console.ReadLine();
            
            var isN = int.TryParse(isInt, out int N);

            if (isNumber & isN)
            {                            
                
                PrintMultiplicationTable(N, number);
                Console.WriteLine("Рrogram completed");               
            }
            else
            {
                Console.WriteLine("You enter not numbers");
            }
        }

       static void PrintMultiplicationTable(int n, int a)
        {
            for (var i = 1; i <= n; i++)
            {
                Console.WriteLine($"{a}*{i}={a * i}");
            }
        }  
            
    }
}
