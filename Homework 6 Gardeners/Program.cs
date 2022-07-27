using System;
using System.Threading;

namespace Homework_6_Gardeners
{
    class Program
    {
        private static int[,] _area;
        private static int _width;
        private static int _length;

        static void Main()
        {

            Console.WriteLine("Enter length of area:");
            var isLength = int.TryParse(Console.ReadLine(), out _length);

            Console.WriteLine("Enter width of area:");
            var isWidth = int.TryParse(Console.ReadLine(), out _width);

            _area = new int[_length, _width];

            Thread gardener1 = new Thread(StepGardener1);
            Thread gardener2 = new Thread(StepGardener2);

            gardener1.Start();
            gardener2.Start();

            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(_area[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void StepGardener1()
        {
            for (int i = 0; i < _length; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_area[i, j] == 0)
                        _area[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void StepGardener2()
        {
            for (int i = _width - 1; i > 0; i--)
            {
                for (int j = _length - 1; j > 0; j--)
                {
                    if (_area[j, i] == 0)
                        _area[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}



