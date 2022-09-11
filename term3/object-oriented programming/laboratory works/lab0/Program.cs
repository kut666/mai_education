using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0
{
    class DemoCarsh
    {
        public static void Main(string[] args)
        {
            double TankVolume, // объём топливного бака 
            FuelFlow, // расход толпива на 100 км 
            Distance, // расчёт расстояния, которое машина проедет с полным баком 
            EnginePower, // мощность двигателя 
            Mass, // масса 
            PowerDensity; // удельная мощность 
            Console.Write("Введите объём топливного бака: ");
            TankVolume = double.Parse(Console.ReadLine());

            Console.Write("Введите расход топлива на 100 км: ");
            FuelFlow = double.Parse(Console.ReadLine());

            Console.Write("Введите мощность двигателя: ");
            EnginePower = double.Parse(Console.ReadLine());

            Console.Write("Введите массу машины: ");
            Mass = double.Parse(Console.ReadLine());

            Carsh C = new Carsh(TankVolume, FuelFlow, EnginePower, Mass);

            Distance = C.Distance();
            Console.WriteLine("Расстояние, которое машина проедет с полным баком = " + Distance);

            PowerDensity = C.PowerDensity();
            Console.WriteLine("Удельная мощность = " + PowerDensity);

            C.InfoCarsh();
            Console.ReadKey();
        }
    }
}
