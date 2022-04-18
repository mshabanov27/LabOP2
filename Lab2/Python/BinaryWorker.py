import pickle
from BookFile import Book


def BinWriter(filename, booklist: list[Book]):
    file = open(filename, 'wb')
    pickle.dump(booklist, file)
    file.close()


def BinReader(filename):
    with open(filename, 'rb') as file:
        bookList: list[Book] = pickle.load(file)
    return bookList
