import random

# Generate a random number between 1 and 10
secret_number = random.randint(1, 25)

# brugerens første gæt
num = int(input("Gæt et tal mellem 1 og 25: "))

# benytter while-loop. != betyder "ikke lig med"
while num != secret_number:
    if num < secret_number:
        print("for lavt, prøv igen: ")
    else:
        print("for højt, prøv igen: ")
    num = int(input("Gæt et tal mellem 1 og 25: "))

print("korrekt!")
