using System.Collections.Generic;

namespace Lab2_BinaryFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "input.dat";
            string outputFileName = "output.dat";
            
            List<Book> catalogue = DataReader.Reader();
            BinaryWorker.BinWriter(inputFileName, catalogue);
            List<Book> readCatalogue = BinaryWorker.BinReader(inputFileName);
            
            Printer.PrintCatalogue(readCatalogue);
            List<Book> authorsBooks = AuthorsBooks.ReceiveAuthorsBooks(readCatalogue);
            Printer.PrintNumOfBooks(authorsBooks);
    
            authorsBooks = SortBooks.SortByName(authorsBooks);
            BinaryWorker.BinWriter(outputFileName, authorsBooks);
            Printer.PrintSortedBooks(authorsBooks);
        }
    }
}