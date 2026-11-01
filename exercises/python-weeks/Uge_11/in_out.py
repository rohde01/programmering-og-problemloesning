def print_string_in_format(string):
    index = len(string)
    if index >= len(string):
        return
    print(string[:index-1])
    print_string_in_format(string, index+1)
    print(string[index:])

print(print_string_in_format("hello"))
