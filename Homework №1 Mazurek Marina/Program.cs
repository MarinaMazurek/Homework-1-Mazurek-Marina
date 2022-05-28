using System;

namespace Homework__1_Mazurek_Marina
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;

            do
            {
                Console.WriteLine("Enter a number day of week: 1..7");
            
                if (int.TryParse(Console.ReadLine(), out int day))
                {
                    Console.WriteLine(GetDayOfWeek(day));
                }
                else
                {
                    Console.WriteLine("You enter not number");
                }

                Console.WriteLine("Do you want enter a number day of week again: Y/N");
                answer = Console.ReadLine();
                
            } while (answer == "y" || answer == "Y");

            Console.WriteLine("Programm is finished");
        }

        static string GetDayOfWeek(int a)
        {
            return a switch
            {
            1 => "Monday", 
            2 => "Tuesday", 
            3 => "Wednesday", 
            4 => "Thursday",  
            5 => "Friday",
            6 => "Saturday",
            7 => "Sunday",
            _ => "You enter uncorrect number"
            };
        }
}
}
