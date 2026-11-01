

def pal(string):
    if string[::-1] == string:
        return True
    else:
        return False
print(pal("EBBE"))