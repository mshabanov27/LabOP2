using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3_ClassesAndObjects
{
    public class Text
    {
        private List<string> _text = new List<string>();

        public Text()
        {
            Console.WriteLine("Adding new text...");
            Console.WriteLine("Press F1 to stop adding data.");
            
            while (Console.ReadKey().Key != ConsoleKey.F1)
            {
                Console.Write("\b");
                _text = _text.Append(Console.ReadLine()).ToList();
            }
        }

        public List<string> GetText
        {
            get {return _text;}
        }
            
        public void AddLine(string newLine)
        {
            _text = _text.Append(newLine).ToList();
        }

        public int FindLinesByLength(int neededLength)
        {
            int counter = 0;
            
            for (int i = 0; i < _text.Count; i++)
            {
                if (_text[i].Length == neededLength)
                    counter++;
            }

            return counter;
        }
    }
}