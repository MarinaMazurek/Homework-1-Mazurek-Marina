using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOMEWORK_3_Plane
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PassangerPlane> passangerPlanes =  GetPassangerPlane();

            foreach (var passangerPlane in passangerPlanes)
            {
                Console.WriteLine($"Plane: {passangerPlane.Name}\n" +
                                  $"Type of plane: {passangerPlane.Type}\n" +
                                  $"Carrying: {passangerPlane.Carrying} tons\n" +
                                  $"Range of Flight: {passangerPlane.RangeOfFlight} km\n" +
                                  $"Fuel consumption: {passangerPlane.FuelConsumption} kg / h\n" +
                                  $"Capacity: {passangerPlane.Capacity} people\n"); ;                
            }

            List<FreightPlane> freightPlanes = GetFreightPlane();

            foreach (var freightPlane in freightPlanes)
            {
                Console.WriteLine($"Plane: {freightPlane.Name}\n" +
                                  $"Type of plane: {freightPlane.Type}\n"+
                                  $"Carrying: {freightPlane.Carrying} tons\n"+
                                  $"Range of Flight: {freightPlane.RangeOfFlight} km\n" +
                                  $"Fuel consumption: {freightPlane.FuelConsumption} kg / h\n" +
                                  $"FreightVolume: {freightPlane.FreightVolume} m3\n");
            }

            AirCompany airCompany = new AirCompany(passangerPlanes, freightPlanes);
           
            Console.WriteLine("Total number of planes in aircompany: {0} planes.\n", airCompany.PassangerPlanes.Count + 
                airCompany.FreightPlanes.Count);

            double totalPlaneCapacity = 0, totalPlaneCarrying = 0, totalPlaneVolume = 0;

            foreach (var plane in passangerPlanes)
            {
                totalPlaneCapacity += plane.Capacity;
                totalPlaneCarrying += plane.Carrying;
            }
            Console.WriteLine("Total capacity: {0}", totalPlaneCapacity + " people");
            Console.WriteLine("Total passanger plane carrying: {0}", totalPlaneCarrying + " tons");
           
            foreach (var plane in freightPlanes)
            {
                totalPlaneVolume += plane.FreightVolume;                
            }
            Console.WriteLine("Total freight plane carrying: {0}", totalPlaneVolume + " m3\n");


            //сортировка по дальности
            var passangerPlanesForSort = passangerPlanes.Select(x => new
            {
                Name = x.Name,
                RangeOfFlight = x.RangeOfFlight,
                FuelConsumption = x.FuelConsumption
            });

            var freightPlanesForSort = freightPlanes.Select(x => new
            {
                Name = x.Name,
                RangeOfFlight = x.RangeOfFlight,
                FuelConsumption = x.FuelConsumption
            });

            var planesForSort = passangerPlanesForSort.Concat(freightPlanesForSort);
                        
            Console.WriteLine("Sorting of planes by flight range:");
            var sorted = planesForSort.OrderBy(plane => plane.RangeOfFlight).ToArray();

            foreach (var plane in sorted)
            {
                Console.WriteLine($"{plane.Name} - {plane.RangeOfFlight} km");
            }

            //найти самолет с диапазоном параметров потребления горючего 
            var count = 0;
            var minValueOfFuelConsumption = 1000;
            var maxValueOfFuelConsumption = 6000;
                        
            Console.WriteLine($"\nPlane with a range of fuel consumption parameters (min = {minValueOfFuelConsumption} kg / h, max = {maxValueOfFuelConsumption} kg/h)");
            foreach (var plane in planesForSort)
            {
                if(plane.FuelConsumption > minValueOfFuelConsumption && plane.FuelConsumption < maxValueOfFuelConsumption)
                {
                    count++;
                    Console.WriteLine($"{plane.Name} - {plane.FuelConsumption} kg / h");                   
                }                
            }
            if(count == 0)
            {
                Console.WriteLine("Plane with such parameters was not found");
            }

            Console.ReadKey();
        }

        public static List<PassangerPlane> GetPassangerPlane()
        {
            string pathPassanger = @"C:\Users\Марина\source\repos\Homework №1 Mazurek Marina\HOMEWORK 3 Plane\planes\notePassenger.txt";

            string name1, name2, name3;
            string type1, type2, type3;
            double carrying1, carrying2, carrying3;
            double rangeOfFlight1, rangeOfFlight2, rangeOfFlight3;
            double fuelConsumption1, fuelConsumption2, fuelConsumption3;
            double capacity1, capacity2, capacity3;

            using (StreamReader reader = new StreamReader(pathPassanger))
            {
                name1 = reader.ReadLine();
                type1 = reader.ReadLine();
                carrying1 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight1 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption1 = Convert.ToDouble(reader.ReadLine());
                capacity1 = Convert.ToDouble(reader.ReadLine());

                name2 = reader.ReadLine();
                type2 = reader.ReadLine();
                carrying2 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight2 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption2 = Convert.ToDouble(reader.ReadLine());
                capacity2 = Convert.ToDouble(reader.ReadLine());

                name3 = reader.ReadLine();
                type3 = reader.ReadLine();
                carrying3 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight3 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption3 = Convert.ToDouble(reader.ReadLine());
                capacity3 = Convert.ToDouble(reader.ReadLine());
            }

            return new List<PassangerPlane> {
            new PassangerPlane(name1, type1, carrying1, rangeOfFlight1, fuelConsumption1, capacity1),
            new PassangerPlane(name2, type2, carrying2, rangeOfFlight2, fuelConsumption2, capacity2),
            new PassangerPlane(name3, type3, carrying3, rangeOfFlight3, fuelConsumption3, capacity3) 
            };
        }

        public static List<FreightPlane> GetFreightPlane()
        {
            string pathFreight = @"C:\Users\Марина\source\repos\Homework №1 Mazurek Marina\HOMEWORK 3 Plane\planes\noteFreight.txt";

            string name1, name2, name3;
            string type1, type2, type3;
            double carrying1, carrying2, carrying3;
            double rangeOfFlight1, rangeOfFlight2, rangeOfFlight3;
            double fuelConsumption1, fuelConsumption2, fuelConsumption3;
            double freightVolume1, freightVolume2, freightVolume3;

            using (StreamReader reader = new StreamReader(pathFreight))
            {
                name1 = reader.ReadLine();
                type1 = reader.ReadLine();
                carrying1 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight1 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption1 = Convert.ToDouble(reader.ReadLine());
                freightVolume1 = Convert.ToDouble(reader.ReadLine());

                name2 = reader.ReadLine();
                type2 = reader.ReadLine();
                carrying2 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight2 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption2 = Convert.ToDouble(reader.ReadLine());
                freightVolume2 = Convert.ToDouble(reader.ReadLine());

                name3 = reader.ReadLine();
                type3 = reader.ReadLine();
                carrying3 = Convert.ToDouble(reader.ReadLine());
                rangeOfFlight3 = Convert.ToDouble(reader.ReadLine());
                fuelConsumption3 = Convert.ToDouble(reader.ReadLine());
                freightVolume3 = Convert.ToDouble(reader.ReadLine());
            }

            return new List<FreightPlane> {
            new FreightPlane(name1, type1, carrying1, rangeOfFlight1, fuelConsumption1, freightVolume1),
            new FreightPlane(name2, type2, carrying2, rangeOfFlight2, fuelConsumption2, freightVolume2),
            new FreightPlane(name3, type3, carrying3, rangeOfFlight3, fuelConsumption3, freightVolume3)
            };
        }
    }    
}
