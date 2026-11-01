
def odds(list):
    r = []
    for i in range(len(list)):
        if i % 2 != 0:
            r.append(list[i])
    return r

print(odds([1, 2, 3, 4, 5, 6, 7, 8]))