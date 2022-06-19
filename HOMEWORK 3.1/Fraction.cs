using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3._1
{
    public class Fraction
    {
        public int Value1 { get; set; }
        public byte Value2 { get; set; }


        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction { Value1 = fraction1.Value1 + fraction2.Value1, Value2 = (byte)(fraction1.Value2 + fraction2.Value2) };
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction { Value1 = fraction1.Value1 - fraction2.Value1, Value2 = (byte)(fraction1.Value2 - fraction2.Value2) };
        }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            if ((fraction1.Value1 > fraction2.Value1)
                || (fraction1.Value1 == fraction2.Value1 && fraction1.Value2 > fraction2.Value2))
            {
                return fraction1.Value1 > (fraction2.Value1);
            }
            return false;
        }
        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            if ((fraction1.Value1 < fraction2.Value1)
                || (fraction1.Value1 == fraction2.Value1 && fraction1.Value2 < fraction2.Value2))
            {
                return (fraction1.Value1) < (fraction2.Value1);
            }
            return false;
        }
    }
}
