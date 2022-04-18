using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_BinaryFiles
{
    public class AuthorsBooks
    {
        public static List<Book> ReceiveAuthorsBooks(List<Book> catalogue)
        {
            Console.Write("Enter the author you`d like to find: ");
            string author = Console.ReadLine();
            
            int occurrences = 0;
            List<Book> authorsBooks = new List<Book>();
            authorsBooks = _findAuthor(catalogue, author, authorsBooks, ref occurrences);
            
            while (occurrences == 0)
            {
                Console.Write("There is no such author. Try again: ");
                author = Console.ReadLine();
                authorsBooks = _findAuthor(catalogue, author, authorsBooks, ref occurrences);
            }

            return authorsBooks;
        }

        private static List<Book> _findAuthor(List<Book> catalogue, string author,  List<Book> authorsBooks, ref int occurrences)
        {
            for (int i = 0; i < catalogue.Count; i++)
            {
                if (catalogue[i].Author == author)
                {
                    authorsBooks = authorsBooks.Append(catalogue[i]).ToList();
                    occurrences++;
                }
            }

            return authorsBooks;
        }
    }
}