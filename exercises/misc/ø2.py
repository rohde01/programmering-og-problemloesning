str = input("enter a string: ")
str2 = ""
for letter in str:
    if letter in "AEOUYÆØÅaeouyæø":
        str2 = str2
    else: 
        str2 = str2 + letter
print(str2) 
