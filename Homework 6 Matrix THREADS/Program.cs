using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_6_Matrix_THREADS
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] m1 = new int[1000, 1000]; //объяление матрицы 1
            int[,] m2 = new int[1000, 1000];//объяление матрицы 2
            int[,] m3 = new int[1000, 1000]; //объяление произведения матрицы
            Random ran = new Random();  // Заполнение случайными числами

            for (int m = 0; m < 100; m++)
            {

                for (int je = 0; je < 100; je++)
                {
                    m1[m, je] = ran.Next(30); // ran.Next(функция задает максимально допустимое значение);
                    m2[m, je] = ran.Next(30);
                }
            }

            for (int m = 0; m < 100; m++)
            {
                for (int je = 0; je < 100; je++)
                {
                    m3[m, je] = m1[m, je] * m2[m, je]; // Произведение матриц
                }
            }

            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Матриц m1 и m2:");
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        Console.Write(m1[i, j].ToString("000") + " "); // вывод в консоль м1
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Матриц m2:");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(m2[i, j].ToString("000") + " "); // вывод в консоль м2
                }
                Console.WriteLine();
            }

            Console.WriteLine("Произведение двумерных матриц m1 и m2:");
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    Console.Write(m3[i, j].ToString("000") + " "); // вывод в консоль *
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}