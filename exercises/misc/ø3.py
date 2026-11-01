arr = [2, 4, 6, 5, 6, 7]

list = []
for i in arr:
    if i < max(arr):
        list.append(i)
print(max(list))