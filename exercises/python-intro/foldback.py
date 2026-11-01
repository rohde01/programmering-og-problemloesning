from functools import reduce

#reducefunktionen kan bruges til at lave en foldback operation på et element, fx en liste.
#herunder tager reduce funktionen to argumenter, en anonym funktion og en liste
numbers = [1, 2, 3, 4]
total = reduce(lambda x, y: x + y, numbers)
print(total)  # Output: 10
