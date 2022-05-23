using System;

namespace Lab4_OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
            var B1 = new Vector();
            
            var B2 = GetInput.getVector2Data();
            
            var B3 = GetInput.getVector3Data();

            Console.WriteLine($"Before change: \n Vector 1: {B1} \n Vector 2: {B2} \n Vector 3: {B3}");
            
            B3.TurnVector(45);
            B2 = B2 / 2;
            B1 = B2 + B3;
            
            Console.WriteLine($"After change: \n Vector 1: {B1} \n Vector 2: {B2} \n Vector 3: {B3}");
        }
    }
}