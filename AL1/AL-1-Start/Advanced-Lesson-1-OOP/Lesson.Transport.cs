using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Lesson_1_OOP
{
    public static partial class Lesson
    {

        public static void InheritanceTransportExample()
        {
            //Transport transport = new FuelCar() { FuelUsage = 10, Fuel = 45, Distance = 25045 };
            //var transport2 = new Transport { Distance = 34, MaxSpeed = 5 };

            //Transport unknowedTransport = new Transport { Distance = 34, MaxSpeed = 5 };
            //unknowedTransport = new FuelCar() { FuelUsage = 10, Fuel = 45, Distance = 25045 };
            ////var fuel = unknowedTransport.Fuel;

            //FuelCar maserati = new FuelCar() { FuelUsage = 10, Fuel = 45, Distance = 25045 };
            //Transport winner = maserati;
            //FuelCar firstPlace = (FuelCar)winner;

            FuelCar fuelCar1 = new FuelCar() { Engine = 400, Fuel = 45, Distance = 25045 };
            FuelCar fuelCar2 = new FuelCar() { Engine = 400, Fuel = 45, Distance = 25045 };

            if (fuelCar1.Engine > fuelCar2.Engine)
                Console.WriteLine($"Наибольная мощность машины 1: {fuelCar1.Engine}");
            else if (fuelCar1.Engine < fuelCar2.Engine)
                Console.WriteLine($"Наибольная мощность машины 2: {fuelCar2.Engine}");
            else if (fuelCar1.Engine == fuelCar2.Engine)
                Console.WriteLine($"Мощности обоих машин равны: {fuelCar2.Engine}");

            bool result = fuelCar1.Engine != fuelCar2.Engine;
            if (result==true)
                Console.WriteLine($"Мощности обоих машин неравны.");
        }   
    }

    public class Transport
    {
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public int MaxSpeed { get; set; }
        public float Distance { get; set; }

        public virtual void Move(float km)
        {
            this.Distance += km;
        }
    }

    public class Car : Transport
    {
        public float Engine { get; set; }
    }

    public class FuelCar : Car
    {
        public int Tank { get; set; }
        public float Fuel { get; set; }
        public float FuelUsage { get; set; }

        public override void Move(float km)
        {
            base.Move(km);
            this.Fuel -= km * FuelUsage / 100;
        }

        public static bool operator < (FuelCar car1, FuelCar car2)
        {
            return car1.Engine < car2.Engine;
        }

        public static bool operator > (FuelCar car1, FuelCar car2)
        {
            return car1.Engine > car2.Engine;
        }

        public static bool operator == (FuelCar car1, FuelCar car2)
        {
            return car1.Engine == car2.Engine;
        }

        public static bool operator != (FuelCar car1, FuelCar car2)
        {
            return car1.Engine != car2.Engine;
        }
    }

    public class ElectroCar : Car
    {
        public int Battery { get; set; }
        public float Charged { get; set; }
        public float DistanceBattery { get; set; }

        public override void Move(float km)
        {
            base.Move(km);
            this.Charged -= Battery * km / DistanceBattery;
        }
    }


}
