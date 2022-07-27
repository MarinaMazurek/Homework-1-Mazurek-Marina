using System;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_6_Matrix
{
    class Program
    {
        private const int DIM = 10; // при желании можно изменить на 1000

        static void Main(string[] args)
        {
            Console.WriteLine("The first matrix:");
            var A = InitializationMatrix();
            
            Thread.Sleep(100);
            
            Console.WriteLine("\nThe second matrix:");
            var B = InitializationMatrix();

            Console.WriteLine("\nResult matrix:");
            var C = MultiplicationMatrix(A, B);

            Console.ReadLine();
        }

        private static int[,] InitializationMatrix()
        {
            var matrix = new int[DIM, DIM];

            var rand = new Random();            

            for (int i = 0; i < DIM; i++)
            {
                for (int j = 0; j < DIM; j++)
                {
                    matrix[i, j] = rand.Next(1, 15);
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }

            return matrix;
        }              

        private static int[,] MultiplicationMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            var resultMatrix = new int[DIM, DIM];
            var task = new Task(() =>
            {
                for (int i = 0; i < firstMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < secondMatrix.GetLength(1); j++)
                    {
                        for (int k = 0; k < secondMatrix.GetLength(0); k++)
                        {
                            resultMatrix[i, j] += firstMatrix[i, k] * secondMatrix[k, j];
                        }
                        Console.Write(resultMatrix[i, j] + ", ");
                    }
                    Console.WriteLine();
                }
            });
            task.Start();

            return resultMatrix;
        }
    }
}


