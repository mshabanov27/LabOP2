namespace Lab5_InheritanceAndPolymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] firstMatrix = RandomSystemGenerator.GenerateRandomSystem(2);
            TwoSystemLinearEquation firstSystem = new TwoSystemLinearEquation(firstMatrix);
            Printer.PrintSystem(firstSystem);
            double[] firstRoots = firstSystem.MatrixMethod();
            Printer.PrintRoots(firstRoots);
            
            double[,] secondMatrix = RandomSystemGenerator.GenerateRandomSystem(2);
            TwoSystemLinearEquation secondSystem = new TwoSystemLinearEquation(secondMatrix);
            Printer.PrintSystem(secondSystem);
            double[] secondRoots = secondSystem.KramerMethod();
            Printer.PrintRoots(secondRoots);
            
            double[,] thirdMatrix = RandomSystemGenerator.GenerateRandomSystem(3);
            ThreeSystemLinearEquation thirdSystem = new ThreeSystemLinearEquation(thirdMatrix);
            Printer.PrintSystem(thirdSystem);
            double[] thirdRoots = thirdSystem.MatrixMethod();
            Printer.PrintRoots(thirdRoots);
            
            double[,] fourthMatrix = RandomSystemGenerator.GenerateRandomSystem(3);
            ThreeSystemLinearEquation fourthSystem = new ThreeSystemLinearEquation(fourthMatrix);
            Printer.PrintSystem(fourthSystem);
            double[] fourthRoots = fourthSystem.KramerMethod();
            Printer.PrintRoots(fourthRoots);
        }
    }
}