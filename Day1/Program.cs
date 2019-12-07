using System;

namespace Day1
{
    class Program
    {
        static string[] MassInputs = System.IO.File.ReadAllLines("data.txt");
        static decimal RequiredFuel = 0;
        static void Main(string[] args)
        {
            foreach (var input in MassInputs)
            {
                var mass = Convert.ToDecimal(input);
                RequiredFuel += CalculateTotalFuelPerMass(mass);
            }   
            Console.WriteLine(RequiredFuel);
        }

        // Part 1 solution
        static decimal CalculateFuelPerMass(decimal mass) {
            return Math.Floor(mass / 3) - 2;
        }

        // Part 2 solution
        static decimal CalculateTotalFuelPerMass(decimal mass) {
            decimal totalFuel = 0;

            while(mass > 0) {
                var fuel = CalculateFuelPerMass(mass);

                if (fuel > 0) {
                    mass = fuel;
                    totalFuel += fuel;
                } else {
                    mass = 0;
                }
            }

            return totalFuel;
        }
    }
}
