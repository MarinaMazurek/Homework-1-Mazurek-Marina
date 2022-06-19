using System;

namespace HOMEWORK_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            TrapezoidParameters();

            Console.WriteLine("\nEnter number of trapezoids:");

            string NumberOfTrapezoid = Console.ReadLine();
            int.TryParse(NumberOfTrapezoid, out int N);

            double[] squares = new double[N];
            double sum = 0;

            for (int i = 0; i < N; i++)
            {
                int x1 = 0;
                int y1 = 0;
                int x2 = 2 + i;
                int y2 = 3 + i;
                int x3 = 5 + i;
                int y3 = 3 + i;
                int x4 = 7 + i;
                int y4 = 0 + i;

                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Point point3 = new Point(x3, y3);
                Point point4 = new Point(x4, y4);

                Trapezoid trapezoid = new Trapezoid(point1, point2, point3, point4);

                squares[i] = Trapezoid.GetSquare(trapezoid);
                sum += squares[i];
            }
                        
            double averageSquare = sum / N;

            int counter = 0;

            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i] > averageSquare)
                    counter++;
            }
            Console.WriteLine($"\nThe number of trapezoids with an area greater than the average: {counter}");

            static void TrapezoidParameters()
            {
                int x1 = 0;
                int y1 = 0;
                int x2 = 2;
                int y2 = 3;
                int x3 = 5;
                int y3 = 3;
                int x4 = 7;
                int y4 = 0;

                Point point1 = new Point(x1, y1);
                Point point2 = new Point(x2, y2);
                Point point3 = new Point(x3, y3);
                Point point4 = new Point(x4, y4);

                Trapezoid trapezoid = new Trapezoid(point1, point2, point3, point4);

                double line1 = Trapezoid.GetLengthOfLine(trapezoid.Point1, trapezoid.Point2);
                Console.WriteLine($"Length of line between point 1, 2: {line1}");

                double line2 = Trapezoid.GetLengthOfLine(trapezoid.Point2, trapezoid.Point3);
                Console.WriteLine($"Length of line between point 2, 3: {line2}");

                double line3 = Trapezoid.GetLengthOfLine(trapezoid.Point3, trapezoid.Point4);
                Console.WriteLine($"Length of line between point 3, 4: {line3}");

                double line4 = Trapezoid.GetLengthOfLine(trapezoid.Point4, trapezoid.Point1);
                Console.WriteLine($"Length of line between point 4, 1: {line4}");

                if (Trapezoid.CheckIsoscelesOfTrapezoid(trapezoid))
                {
                    Console.WriteLine("\nTrapezoid is isosceles");
                }
                else Console.WriteLine("\nTrapezoid is not isosceles");

                Console.WriteLine($"\nPerimeter of trapezoid: {Trapezoid.GetPerimetr(trapezoid)}");
                Console.WriteLine($"\nSquare of trapezoid: {Trapezoid.GetSquare(trapezoid)}");
            }
        }

            
        
    }
}
