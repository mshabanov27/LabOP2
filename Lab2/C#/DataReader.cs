using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab2_BinaryFiles
{
    public class DataReader
    {
        public static List<Book> Reader()
        {
            List<Book> structList = new List<Book>();
            
            Console.WriteLine("Press F1 to stop adding data.");
            while (Console.ReadKey().Key != ConsoleKey.F1)
            {
                Book anotherBook = _dataCollector();
                structList = structList.Append(anotherBook).ToList();
                Console.WriteLine("Press F1 to stop adding data.");
            }

            return structList;
        }

        private static Book _dataCollector()
        {
            Book anotherBook = new Book();
            string numPattern = @"\d";
            
            Console.Write("Enter the name of the book: ");
            anotherBook.Name = _isNotEmpty(Console.ReadLine());
                
            Console.Write("Enter the author: ");
            anotherBook.Author = _isNotEmpty(Console.ReadLine());
                
            Console.Write("Enter the year of publication: ");
            anotherBook.Year = _testForPattern(Console.ReadLine(), numPattern);

            Console.Write("Enter the language: ");
            anotherBook.Language =  _isNotEmpty(Console.ReadLine());

            Console.Write("Enter the number of copies: ");
            anotherBook.NumberOfCopies =_testForPattern(Console.ReadLine(), numPattern);

            return anotherBook;
        }
        
        private static int _testForPattern(string testLine, string pattern)
        {
            while (!Regex.IsMatch(testLine, pattern))
            {
                Console.Write("This is not a number, try again: ");
                testLine = Console.ReadLine();
            }

            return int.Parse(testLine);
        }

        private static string _isNotEmpty(string testLine)
        {
            while (testLine.Replace(" ", "") == "")
            {
                Console.Write("The line is empty, try again: ");
                testLine = Console.ReadLine();
            }

            return testLine;
        }
    }
}