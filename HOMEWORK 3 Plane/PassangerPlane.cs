using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public class PassangerPlane : Plane
    {
        public double Capacity { get; set; }  //  вместимость, чел.

        public PassangerPlane(string name, string type, double carrying, double rangeOfFlight,
            double fuelConsumption, double capacity) : base(name, type, carrying, rangeOfFlight, fuelConsumption)
        {
            Capacity = capacity;
        }
    }
}
