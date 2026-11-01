
num1 = int(input("Indtast tal: "))
list = list(range(num1))
list.append(num1)
list.remove(0)

for i in list:
    if i % 3 == 0:
        print("Fizz")
    elif i % 5 == 0:
        print("Buzz")
    else:
        print(str(i))
    
