from BookFile import Book


def reader():
    structList = []

    while True:
        print('Press slash to stop adding data.')
        endReading = input()
        if endReading == "/":
            break
        else:
            newBook = dataCollector()
            structList.append(newBook)

    return structList


def dataCollector():
    anotherBook = Book()
    anotherBook.name = input('Enter the name of the book: ')
    anotherBook.author = input('Enter the author: ')

    anotherBook.year = input('Enter the year: ')
    while not anotherBook.year.isnumeric():
        anotherBook.year = input('That`s not a number, enter the valid year: ')

    anotherBook.language = input('Enter the language: ')
    anotherBook.numberOfCopies = input('Enter the number of copies: ')

    while not anotherBook.numberOfCopies.isnumeric():
        anotherBook.numberOfCopies = input('That`s not a number, enter valid data: ')

    return anotherBook
