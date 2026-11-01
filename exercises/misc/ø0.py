n = 5

list = list(range(n))
list.append(n)
list.remove(0)
string = ""
    
for i in list:
    string = string + str(i)
print(string)
        