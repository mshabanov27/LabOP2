namespace Lab6_Trees
{
    public class Node
    {
        
        private char _data;
        private Node _left;
        private Node _right;

        public Node(char data)
        {
            _data = data;
        }
        
        public char Data
        {
            get => _data;
            set => _data = value;
        }

        public Node Left
        {
            get => _left;
            set => _left = value;
        }

        public Node Right
        {
            get => _right;
            set => _right = value;
        }
    }
}