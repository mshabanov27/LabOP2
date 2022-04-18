using System;
using System.Collections.Generic;

namespace Lab2_BinaryFiles
{
    public class Printer
    {
        public static void PrintCatalogue(List<Book> catalogue)
        {
            Console.WriteLine("\n\nFull catalogue:");
            foreach (Book book in catalogue)
            {
                Console.WriteLine();
                Console.WriteLine($"Name: {book.Name} | Author: {book.Author} | Year: {book.Year} | Language: {book.Language} | Number of copies: {book.NumberOfCopies}");
            }
        }

        public static void PrintNumOfBooks(List<Book> authorsBooks)
        {
            Console.WriteLine("\n\nNumber of copies for each book is:");
            foreach (Book book in authorsBooks)
            {
                Console.WriteLine();
                Console.WriteLine($"Author: {book.Author} | Name: {book.Name} | Number of copies: {book.NumberOfCopies}" );
            }
        }
        
        public static void PrintSortedBooks(List<Book> sortedBooks)
        {
            Console.WriteLine("\n\nSorted:");
            foreach (Book book in sortedBooks)
            {
                Console.WriteLine($"Author: {book.Author} | Name: {book.Name}");
            }
        }
    }
}