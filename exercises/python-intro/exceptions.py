#exceptions bruges til at fange fejl, så programmet ikke crasher ved fx forkert input
try:
    number = int(input("enter a number: "))
    print(number)
except ValueError:
    print("invalid input")