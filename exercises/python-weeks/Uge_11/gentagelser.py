#tæller hvor mange gange et element optræder i en liste
def occ(list, o):
    r = 0
    for elm in list:
        if elm == o:
            r += 1
    return r

print(occ([1, 2, 2, 2], 2))
