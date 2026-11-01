#Åbner filen 
test_file = open("test.txt", "r")

#tjekker om en fil kan læses. returnerer en boolean
print(test_file.readable())

# #læser hele filen og printer den
# print(test_file.read())

# #Tilføjer hver linje som element til en liste. herefter kan man vælge at printe en bestemt indeksplads []
# print(test_file.readlines()[2])

#readLines kan fx bruges med et forloop, som kan printe alle elementer i listen
for test in test_file.readlines():
    print (test)


#Lukker filen
test_file.close()