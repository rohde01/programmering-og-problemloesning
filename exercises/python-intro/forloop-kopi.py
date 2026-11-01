# fam = ["Mor", "Far", "Jacob", "Frederik", "Caroline"]
# intList = [17, 2, 32, 4, 11]

# for mem in fam:
#     print(mem)

# # #printer alle tal i intervallet 0-3
# # for index in range(3):
# #     print(index)

# print(len(fam))

#funktionen herunder udregner potensen af to tal
def raise_(num1, num2):
    result = 1
    for index in range(num2):
        result = num1 * result
    return result

print(raise_(5, 2))


