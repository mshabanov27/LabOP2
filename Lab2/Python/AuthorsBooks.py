from BookFile import Book


def receiveAuthorsBooks(catalogue):
    author = input('Enter the author you`d like to find: ')
    occurrences = 0
    authorsBooks = []
    for books in catalogue:
        if author == books.author:
            authorsBooks.append(books)
            occurrences += 1

    while occurrences == 0:
        author = input('There is no such author. Try again:  ')
        for books in catalogue:
            if author == books.author:
                authorsBooks.append(books)
                occurrences += 1

    return authorsBooks
