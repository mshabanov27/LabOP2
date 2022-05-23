using System;
using System.Text.RegularExpressions;

namespace Lab4_OperatorOverloading
{
    public static class GetInput
    {
        public static Vector getVector2Data()
        {
            Console.Write("Enter the length of vector 2: ");
            var vect2Length = _getNumbers();
            Console.Write("Enter the angle of vector 2 in degrees: ");
            var vect2Angle = _getNumbers();

            return new Vector(vect2Length, vect2Angle);
        }
        
        public static Vector getVector3Data()
        {
            Console.Write("Enter the length of vector 3: ");
            var vect3Length = _getNumbers();
            
            return new Vector(vect3Length);
        }
        
        private static double _getNumbers()
        {
            double number = _checkOnNumber(Console.ReadLine());
            return number;
        }

        private static double _checkOnNumber(string input)
        {
            while (!Regex.IsMatch(input, @"^\d+[,]?\d*$"))
            {
                Console.Write("Not a number! Try again: ");
                input = Console.ReadLine();
            }

            return Double.Parse(input);
        }
    }
}