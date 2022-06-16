using System;

namespace Lab5_InheritanceAndPolymorphism
{
    public class Printer
    {
        public static void PrintSystem(TSystemLinearEquation system)
        {
            Console.WriteLine($"System: \n{system}");
        }

        public static void PrintRoots(double[] roots)
        {
            if (roots != null)
            {
                for (int i = 0; i < roots.Length; i++)
                    Console.WriteLine($"{(char) (i + 120)} = {roots[i]}");
                Console.WriteLine("\n\n");
            }
            else
                Console.WriteLine("System has infinite quantity of roots.\n\n");
        }
    }
}