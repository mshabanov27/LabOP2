def writeToFile(text, filename, appendText):
    textFile = open(filename, appendText)
    textFile.write(text)
    textFile.close()


def readFromFile(filename):
    textFile = open(filename, "r")
    text = textFile.read()
    textFile.close()
    return text


def readText():
    messages = []
    while True:
        line = input()
        if line == '/':
            print("\nEnd of writing")
            break
        else:
            messages.append(line)
    text = '\n'.join(messages)
    return text


def editText(text):
    text = text.replace('\n', '. ')
    text = text.replace('.\n', '. ')
    sentencesList = text.split('. ')
    editedList = []
    for sentences in sentencesList:
        if sentences != '':
            wordsList = sentences.split(' ')
            longestLength = len(modifier(wordsList[0]))
            longestString = modifier(wordsList[0])
            for words in wordsList:
               if len(modifier(words)) > longestLength and words != '':
                  longestLength = len(modifier(words))
                  longestString = modifier(words)
            editedList.append(f"{longestLength} {longestString} {sentences}")

    edited = '\n'.join(editedList)
    return edited


def modifier(word):
    if ';' in word:
        word = word[:-1]
    if '.' in word:
        word = word[:-1]
    if ',' in word:
        word = word[:-1]
    return word


writeToFile(readText(), 'PyInput.txt', 'a')
writeToFile(editText(readFromFile('PyInput.txt')), 'PyOutput.txt', 'w')
print("\n" + readFromFile('PyInput.txt') + "\n")
print("\n" + readFromFile('PyOutput.txt') + "\n")
