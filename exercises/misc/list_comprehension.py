#Hackerrank/prepare/python/list comprehensions
x = 1
y = 1
z = 2
n = 4

l = [[i, j, k] for i in range(x+1) for j in range(y+1) for k in range(z+1) if i+j+k!=n]

print(l)