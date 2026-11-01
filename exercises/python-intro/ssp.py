import random

# listen med muligheder
options = ["sten", "saks", "papir"]

# brugeren vælger
userchoice = input(" sten, saks, eller papir?: ")

# modulet vælger en tilfældig mulighed fra options listen
computerchoice = random.choice(options)

if userchoice == computerchoice:
    print("uafgjort")
elif userchoice == "sten" and computerchoice == "saks":
    print("Du vandt!")
elif userchoice == "saks" and computerchoice == "papir":
    print("Du vandt!")
elif userchoice == "papir" and computerchoice == "sten":
    print("Du vandt!")
else: 
    print("Computer vandt!")