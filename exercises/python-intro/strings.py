
#Print en trekant
print("   /|")
print("  / |")
print(" /  |")
print("/___|")

#variabel test
name_test = "Emil"
age_test = "23"
print( "min ven " + name_test + " er " + age_test + " år gammel")
#overskriv variabel 
name_test = "anders"
age_test = "233"
print( "min ven " + name_test + " er " + age_test + " år gammel")

#linjeskift kommando
print("test\nny linje")

#concatination og funktioner - strings
print("test " + name_test)
#eksempel på funktion. ændrer her streng til store bogstaver
print(name_test.upper())
#returnerer længden på en string
print(len(name_test))
#printer et bogstavet på indeksplads 1
print(name_test[1])
#indsæt nyt bogstav på bestemt plads
print(name_test.replace([0], "A"))

