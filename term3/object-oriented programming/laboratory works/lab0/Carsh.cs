using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0
{
    class Carsh
    {
        private double TankVolume; // объём топливного бака 
        private double FuelFlow; // расход топлива на 100 км 
        private double EnginePower; // мощность двигателя 
        private double Mass; // масса 

        public Carsh(double TankVolume_rpm, double FuelFlow_rpm, double EnginePower_rpm, double Mass_rpm) // конструктор 
        {
            this.TankVolume = TankVolume_rpm;
            this.FuelFlow = FuelFlow_rpm;
            this.EnginePower = EnginePower_rpm;
            this.Mass = Mass_rpm;
        }

        public double Distance() //расстояние, которое проедет машина с полным баком 
        {
            return TankVolume / FuelFlow * 100;
        }

        public double PowerDensity() // удельная мощность 
        {
            return EnginePower / Mass;
        }

        public void InfoCarsh()
        {
            Console.WriteLine("Объем топливного бака: " + TankVolume);
            Console.WriteLine("Расход топлива на 100 км: " + FuelFlow);
            Console.WriteLine("Мощность двигателя: " + EnginePower);
            Console.WriteLine("Масса машины: " + Mass);
        }
        public void InfoCarch(int num)
        {
            Console.WriteLine("Перегрузка метода инфо");
        }

    }
}