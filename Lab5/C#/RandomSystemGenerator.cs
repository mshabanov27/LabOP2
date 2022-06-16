using System;

namespace Lab5_InheritanceAndPolymorphism
{
    public class RandomSystemGenerator
    {
        public static double[,] GenerateRandomSystem(int variablesQuantity)
        {
            Random rand = new Random();
            double[,] system = new double[variablesQuantity, variablesQuantity + 1];

            for (int i = 0; i < variablesQuantity; i++)
                for (int j = 0; j < variablesQuantity + 1; j++)
                    system[i, j] = Math.Round(rand.NextDouble() * 9);

            return system;
        }
    }
}