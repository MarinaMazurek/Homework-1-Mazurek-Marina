using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3._3
{
    public class Trapezoid
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public Point Point4 { get; set; }

        public Trapezoid(Point point1, Point point2, Point point3, Point point4)    ///конструктор
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            Point4 = point4;
        }
        public static double GetLengthOfLine(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow((p1.X - p2.X), 2) + Math.Pow((p1.Y - p2.Y), 2));
        }
        public static double GetPerimetr(Trapezoid trapezoid)
        {
            double line1 = GetLengthOfLine(trapezoid.Point1, trapezoid.Point2);
            double line2 = GetLengthOfLine(trapezoid.Point2, trapezoid.Point3);
            double line3 = GetLengthOfLine(trapezoid.Point3, trapezoid.Point4);
            double line4 = GetLengthOfLine(trapezoid.Point4, trapezoid.Point1);

            return line1 + line2 + line3 + line4;
        }

        public static double GetSquare(Trapezoid trapezoid)
        {
            double line2 = GetLengthOfLine(trapezoid.Point2, trapezoid.Point3);
            double line4 = GetLengthOfLine(trapezoid.Point4, trapezoid.Point1);

            return Math.Pow(((line2 + line4) / 2), 2);
        }

        public static bool CheckIsoscelesOfTrapezoid(Trapezoid trapezoid)
        {
            double line1 = GetLengthOfLine(trapezoid.Point1, trapezoid.Point2);
            double line3 = GetLengthOfLine(trapezoid.Point3, trapezoid.Point4);

            if (line1 == line3)
            {
                return true;
            }
            return false;
        }

    }
}
