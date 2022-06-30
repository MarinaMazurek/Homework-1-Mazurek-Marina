using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public class FreightPlane : Plane
    {
        public double FreightVolume { get; set; }  //  объем перевозимого груза
        public FreightPlane(string name, string type, double carrying, double rangeOfFlight,
            double fuelConsumption, double freightVolume) : base(name, type, carrying, rangeOfFlight, fuelConsumption)
        {
            FreightVolume = freightVolume;
        }
    }
}
