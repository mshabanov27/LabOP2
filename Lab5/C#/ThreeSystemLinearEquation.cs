using System;

namespace Lab5_InheritanceAndPolymorphism
{
    public class ThreeSystemLinearEquation : TSystemLinearEquation
    {
        public ThreeSystemLinearEquation(double[,] coefficients) : base(coefficients)
        {
            if(coefficients.GetLength(0) == 3 && coefficients.GetLength(1) == 4)
                _coefficients = coefficients;
            else
                Console.WriteLine("This ain`t a three variables system.");
        }
    }
}