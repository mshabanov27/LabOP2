using System;
using System.Text.RegularExpressions;

namespace Lab3_ClassesAndObjects
{
    public class OperateTextObjects
    {
        public static Text[] CreateArrOfTexts()
        {
            Console.Write("Enter the length of array: ");
            int length = _checkForNumber(Console.ReadLine());
            Text[] texts = new Text[length];

            for (int i = 0; i < texts.Length; i++)
                texts[i] = new Text();

            return texts;
        }

        public static void AddLinesToTexts(Text[] texts)
        {
            Console.WriteLine("Now start adding lines, press F1 if you don't want to.");
            while (Console.ReadKey().Key != ConsoleKey.F1)
            {
                _addLinesToSpecText(texts);
                Console.WriteLine("Press F1 to stop adding lines.");
            }
        }

        public static Text FindTextWithMaxLines(Text[] texts)
        {
            Console.Write("Enter the length of line: ");
            int lengthOfLine = _checkForNumber(Console.ReadLine());
            int[] counts = _findLines(texts, lengthOfLine);

            while (_isEmpty(counts))
            {
                Console.Write("There are no lines of such length, try again: ");
                lengthOfLine = _checkForNumber(Console.ReadLine());
                counts = _findLines(texts, lengthOfLine);
            }
            
            int maxLinesIndex = _findIndexOfMax(counts);
            return texts[maxLinesIndex];
        }
        
        private static int _checkForNumber(string checkedNum)
        {
            Regex numPattern = new Regex(@"\d");
            while (checkedNum == null || !numPattern.IsMatch(checkedNum))
            {
                Console.Write("Not a number, try again: ");
                checkedNum = Console.ReadLine();
            }

            return int.Parse(checkedNum);
        }
        
        private static void _addLinesToSpecText(Text[] texts)
        {
            Console.Write("\nEnter the index of the text to add the line: ");
            int index = _checkForNumber(Console.ReadLine());
            while (index > texts.Length - 1)
            {
                Console.Write("Too big, try again: "); 
                index = _checkForNumber(Console.ReadLine());
            }

            texts[index].AddLine(Console.ReadLine());
        }

        private static int _findIndexOfMax(int[] arr)
        {
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] > arr[index])
                    index = i;

            return index;
        }

        private static int[] _findLines(Text[] texts, int lengthOfLine)
        {
            int[] counts = new int[texts.Length];
            
            for (int i = 0; i < texts.Length; i++)
                counts[i] = texts[i].FindLinesByLength(lengthOfLine);

            return counts;
        }
        
        private static bool _isEmpty(int[] arr)
        {
            int counter = 0;
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != 0)
                    counter++;

            if (counter == 0)
                return true;
            
            return false;
        }
    }
}