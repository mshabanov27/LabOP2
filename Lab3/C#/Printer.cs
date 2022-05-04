using System;
using System.Collections.Generic;

namespace Lab3_ClassesAndObjects
{
    public class Printer
    {
        public static void PrintTexts(Text[] texts)
        {
            Console.WriteLine("\nAll texts:");
            
            for (int i = 0; i < texts.Length; i++)
            {
                Console.WriteLine($"\nText {i + 1}:");
                List<string> lines = texts[i].GetText;
                for (int j = 0; j < lines.Count; j++)
                {
                   Console.WriteLine(lines[j]); 
                }
            }
        }

        public static void PrintSpecText(Text text)
        {
            Console.WriteLine("\nThe text with biggest number of lines with given length:");
            List<string> lines = text.GetText;
            
            for (int i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}