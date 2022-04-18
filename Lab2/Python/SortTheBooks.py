from BookFile import Book


def SortBooks(authorsBooks: list[Book]):
    i = 0
    while i < len(authorsBooks):
        currentLetter = 0
        j = 0
        while j < len(authorsBooks) - i - 1:
            if authorsBooks[j].name[currentLetter] > authorsBooks[j + 1].name[currentLetter]:
                authorsBooks[j], authorsBooks[j + 1] = authorsBooks[j + 1], authorsBooks[j]
                j += 1
                currentLetter = 0
            elif authorsBooks[j].name[currentLetter] == authorsBooks[j + 1].name[currentLetter] and currentLetter < len(authorsBooks[j].name) and currentLetter < len(authorsBooks[j + 1].name):
                currentLetter += 1
            else:
                j += 1
                currentLetter = 0
        i += 1

    return authorsBooks
