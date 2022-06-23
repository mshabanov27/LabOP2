namespace Lab6_Trees
{
    public class TreeBuilder
    {
        public static Tree BuildTree(char[] elements)
        {
            Tree symbolTree = new Tree(elements[0]);
            for (int i = 1; i < elements.Length; i++)
                symbolTree.AddNode(elements[i]);

            return symbolTree;
        }
    }
}