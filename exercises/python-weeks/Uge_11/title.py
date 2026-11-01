def title(string):
    # Split the string into a list of words
    words = string.split()

    # Iterate over the list of words
    for i in range(len(words)):
        # Capitalize the first letter of the word
        words[i] = words[i][0].upper() + words[i][1:]

    # Join the list of words back into a single string
    return " ".join(words)
print(title("test test test"))