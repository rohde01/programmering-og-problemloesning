# #8ø0
# n = int(input("fac of what? "))
# def factorial(n):
#   result = 1
#   while n > 1:
#     result *= n
#     n -= 1
#   return result

# print(factorial(n))

#8ø3
def create(n):
  table = []
  for i in range(1, 11):
    row = []
    for j in range(1, n+1):
      row.append(i * j)
    table.append(row)
  return table

print(create(2))