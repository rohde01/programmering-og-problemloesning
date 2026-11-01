
num1 = float(input("Indtast første tal: "))
action = input("indtast operator: ")
num2 = float(input("Indtast andet tal: "))

if action == "+":
    print(num1 + num2)
elif action == "-":
    print(num1 - num2)
elif action == "*":
    print(num1 * num2)
elif action == "/":
    print(num1 / num2)
else:
    print("not valid")
         
