from BookFile import Book


def printCatalogue(catalogue):
    print('\n\nFull catalogue:')
    for book in catalogue:
        line = f'Name: {book.name} | Author: {book.author} | Year: {book.year} '
        line += f'| Language: {book.language} | Number of copies: {book.numberOfCopies}'
        print(line)


def printNumOfBooks(authorsBooks):
    print('\n\nNumber of copies for each book is:')
    for book in authorsBooks:
        print(f'Author: {book.author} | Name: {book.name} | Number of copies: {book.numberOfCopies}')


def printSortedBooks(sortedBooks):
    print('\n\nSorted:')
    for book in sortedBooks:
        print(f'Author: {book.author} | Name: {book.name}')
