#2D-lister, kan bruges til at skabe en koordinasystemsstruktur. Det er i princippet bare en liste med lister
grid = [
    [1, 2, 3], 
    [4, 5, 6], 
    [7, 8, 9], 
    [0]
]
#Herunder printer jeg tallet på en bestemt indeksplads 
print(grid[0][1])

#herunder ses et "nested" for-loop. det er et for-loop, inde i et for-loop, som herunder først finder alle listerne i den store liste
#og derefter finder alle elementerne i hver af listerne 
for row in grid:
    for col in row:
        print(col)