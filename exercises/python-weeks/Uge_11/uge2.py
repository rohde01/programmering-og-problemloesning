# #2ø0
# f_name = "Carl-Emil"
# l_name = " Rohde"
# print(f_name + l_name)

#2ø1
num1 = int(input("fac of what? "))

def factorial(num1):
  if num1 == 1:
    return 1
  else:
    return num1 * factorial(num1-1)

print(factorial(num1))
