using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public abstract class Plane
    {
        public string Name { get; set; }
        public string Type { get; set; }       // пассажирский грузовой       
        public double Carrying { get; set; }  // грузоподъемность, тонн
        public double RangeOfFlight { get; set; }  // дальность полета, км
        public double FuelConsumption { get; set; } //потребление топлива, кг/ч

        public Plane(string name, string type, double carrying, double rangeOfFlight, double fuelConsumption)
        {
            Name = name;
            Type = type;
            Carrying = carrying;
            RangeOfFlight = rangeOfFlight;
            FuelConsumption = fuelConsumption;
        }

        public abstract void PrintInfo();
    }
}
