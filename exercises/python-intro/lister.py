stringlist = ["Mor", "Far", "Jacob", "Frederik", "Caroline"]
intList = [17, 2, 32, 4, 11]

# #print hele listen
# print(intList)

# #print det der står på en bestemt indeksplads
# print(stringlist[1])

# #print det der står på en indeksplads og alt til højre
# print(stringlist[1:])

# #print et bestemt interval af indekspladser 
# print(stringlist[0:3])

# #opdater en indeksplads med en ny værdi
# stringlist[3] = "Valentina"
# print(stringlist)

# #Sæt to lister sammen
# stringlist.extend(intList)
# print(stringlist)

#Appending (tilføj element til liste)
stringlist.append("Carl-Emil")

#Insert element i liste på bestemt indeksplads. eksisterende elementer skubbes én til højre.
stringlist.insert(2, "Helena")

# #Fjern et element fra liste
# stringlist.remove("Helena")

# #Ryd en hel liste
# stringlist.clear()

# #fjern det sidste element i en liste
# stringlist.pop()

# #returner et bestemt elements indeksplads i listen
# print(stringlist.index("Frederik"))

# #Tæl antallet af et bestemt element i en liste 
# print(stringlist.count("Carl-Emil"))

#sorter liste efter alfabetisk orden eller størrelse på tal
stringlist.sort()
intList.sort()

#byt om på rækkefølgen på alle elementer i en listes
stringlist.reverse()

# #lav en klon af en liste
# clone = stringlist.copy()


print(stringlist)

#printer anatallet af elementer i en liste
print(len(stringlist))