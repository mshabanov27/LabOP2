from BookFile import Book
import DataReader
import BinaryWorker
import AuthorsBooks
import Printer
import SortTheBooks

inputFileName = "input.dat"
outputFileName = "output.dat"

catalogue: list[Book] = DataReader.reader()
BinaryWorker.BinWriter(inputFileName, catalogue)
readCatalogue: list[Book] = BinaryWorker.BinReader(inputFileName)

Printer.printCatalogue(readCatalogue)
authorsBooks: list[Book] = AuthorsBooks.receiveAuthorsBooks(readCatalogue)
Printer.printNumOfBooks(authorsBooks)

sortedBooks = SortTheBooks.SortBooks(authorsBooks)
BinaryWorker.BinWriter(outputFileName, sortedBooks)
Printer.printSortedBooks(authorsBooks)
