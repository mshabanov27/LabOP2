using System;

namespace Lab5_InheritanceAndPolymorphism
{
    public class TwoSystemLinearEquation : TSystemLinearEquation
    {
        public TwoSystemLinearEquation(double[,] coefficients) : base(coefficients)
        {
            if(coefficients.GetLength(0) == 2 && coefficients.GetLength(1) == 3)
                _coefficients = coefficients;
            else
                Console.WriteLine("This ain`t a two variables system.");
        }
    }
}