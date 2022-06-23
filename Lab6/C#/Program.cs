namespace Lab6_Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = InputReceiver.RecieveTreeData();
            Tree symbolTree = TreeBuilder.BuildTree(symbols);
            Printer.PrintTree(symbolTree);
            char searched = InputReceiver.ReceiveChar();
            Printer.PrintResults(searched, symbolTree);
        }
    }
}