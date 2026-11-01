#3ø0 c)
def create_list(x, string):
  result = []
  for i in range(x):
    result.append(string)
  return result

print(create_list(3, "Hello"))

#3ø0 f)
def create_list(x):
  result = []
  for i in range(1, x+1):
    result.append(i)
  return result
print(create_list(10))

#3ø0 g) her er range brugt i omvendt orden, så der tælles ned med trin-værdi på -1
def create_list(x):
  result = []
  for i in range(x, 0, -1):
    result.append(i)
  return result
print(create_list(10))

#3ø1
def create_list(list):
    list2 = []
    for i in list:
        list2.append(float(i) / 2)
    return list2
print(create_list([5, 10, 20, 45, 56, 34, 89]))
