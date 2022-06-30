using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public class FreightPlane : Plane, IComparable<FreightPlane>
    {
        public double FreightVolume { get; set; }  //  объем перевозимого груза
        public FreightPlane(string name, string type, double carrying, double rangeOfFlight,
            double fuelConsumption, double freightVolume) : base(name, type, carrying, rangeOfFlight, fuelConsumption)
        {
            FreightVolume = freightVolume;
        }

        public int CompareTo(FreightPlane? freightPlane)
        {
            if (freightPlane is null) throw new ArgumentException("Incorrect parameter value");

            return (int)(RangeOfFlight - freightPlane.RangeOfFlight);
        }
    }
}
