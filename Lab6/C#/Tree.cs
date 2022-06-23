using System;
using System.Linq;

namespace Lab6_Trees
{
    public class Tree
    {
        private Node _root;

        public Tree(char rootSym)
        {
            Node root = new Node(rootSym);
            _root = root;
        }

        public Node Root => _root;

        public void AddNode(char insertedSym)
        {
            Node newNode = new Node(insertedSym);
            bool continueSearch = true;
            Node current = _root;
            while (continueSearch)
            {
                Node tempParent = current;
                if (newNode.Data < current.Data)
                {
                    current = current.Left;
                    if (current == null)
                    {
                        tempParent.Left = newNode;
                        continueSearch = false;
                    }
                }
                else
                {
                    current = current.Right;
                    if (current == null)
                    {
                        tempParent.Right = newNode;
                        continueSearch = false;
                    }
                }
            }
        }

        public bool CheckElementPresence(Node current, char checkedElement)
        {
            bool presenceLeft = false;
            bool presenceRight = false;
            if (current.Data == checkedElement)
                return true;
            if(current.Left != null)
                presenceLeft = CheckElementPresence(current.Left, checkedElement);
            if(current.Right != null)
                presenceRight = CheckElementPresence(current.Right, checkedElement);
            return presenceLeft || presenceRight;
        }

        public int CountElementEntries(Node current, char checkedElement)
        {
            if (current.Data == checkedElement)
                return _checkElementChildren(current, checkedElement, 1);

            return _checkElementChildren(current, checkedElement, 0);
        }

        private int _checkElementChildren(Node current, char checkedElement, int entry)
        {
            if(current.Left != null && current.Right != null)
                return entry + CountElementEntries(current.Left, checkedElement) + CountElementEntries(current.Right, checkedElement);
            if (current.Left != null && current.Right == null)
                return entry + CountElementEntries(current.Left, checkedElement);
            if (current.Right != null && current.Left == null)
                return entry + CountElementEntries(current.Right, checkedElement);
            return entry;
        }

        public string PreOrderTraversal(Node current)
        {
            string spaces = String.Concat(Enumerable.Repeat("\t", _checkLevelOfNode(_root, current, 0)));
            if (current.Left == null && current.Right == null)
                return $"{current.Data}\n";
            
            if (current.Left == null && current.Right != null)
                    return $"{current.Data}_______{PreOrderTraversal(current.Right)}";
            else if (current.Left != null && current.Right == null)
                return $"{current.Data}\n{spaces}\\_______{PreOrderTraversal(current.Left)}";
            else
                return
                    $"{current.Data}_______{PreOrderTraversal(current.Right)}{spaces}\\_______{PreOrderTraversal(current.Left)}";
        }

        private int _checkLevelOfNode(Node currentParent, Node searched, int level)
        {
            if (currentParent == null) 
                return 0;
            
            if (currentParent == searched) 
                return level;
            
            int downlevel = _checkLevelOfNode(currentParent.Left, searched, level + 1);
            if (downlevel != 0) 
                return downlevel;
            
            downlevel = _checkLevelOfNode(currentParent.Right, searched, level + 1);
            return downlevel;
        }
        
        public override string ToString()
        {
            string tree = PreOrderTraversal(_root);
            return tree;
        }
    }
}