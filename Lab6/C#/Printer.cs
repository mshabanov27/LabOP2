using System;

namespace Lab6_Trees
{
    public class Printer
    {
        public static void PrintTree(Tree tree)
        {
            Console.WriteLine("The tree is: \n");
            Console.WriteLine(tree);
        }

        public static void PrintResults(char checkedElement, Tree tree)
        {
            if (tree.CheckElementPresence(tree.Root, checkedElement))
            {
                int entries = tree.CountElementEntries(tree.Root, checkedElement);
                Console.WriteLine($"The element is in the tree, number of entries: {entries}.");
            }
            else
                Console.WriteLine("No such element in the tree.");
        }
    }
}