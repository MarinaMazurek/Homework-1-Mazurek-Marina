using System;
using System.Collections.Generic;
using System.Text;

namespace HOMEWORK_3_Plane
{
    public class PassangerPlane : Plane, IComparable<PassangerPlane>
    {
        public double Capacity { get; set; }  //  вместимость, чел.

        public PassangerPlane(string name, string type, double carrying, double rangeOfFlight,
            double fuelConsumption, double capacity) : base(name, type, carrying, rangeOfFlight, fuelConsumption)
        {
            Capacity = capacity;
        }
        public int CompareTo(PassangerPlane? passangerPlane)
        {
            if (passangerPlane is null) throw new ArgumentException("Incorrect parameter value");
            
            return (int)(RangeOfFlight - passangerPlane.RangeOfFlight);
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {Name} - Type of plane {Type} - Carrying: {Carrying} tons" +
                $"Range of flight: {RangeOfFlight} km - \nFuel consumption: {FuelConsumption} kg / h - " +
                $"Capacity: {Capacity} people\n");
        }
    }
}
