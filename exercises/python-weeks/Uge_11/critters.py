import csv

def read_critters(filename):
    critter_list = []
    with open(filename, newline='') as csvfile:
        critter_reader = csv.reader(csvfile)
        for row in critter_reader:
            critter = {'name': row[0], 'color': row[1], 'points': row[2]}
            critter_list.append(critter)
        del critter_list[0]
        return critter_list

critter_list = read_critters('critters.csv')

def get_color(critter):
  return critter['color']

def color_sort(critter_list, c):
    sorted_list = []
    for elm in critter_list:
        if get_color(elm) == c:
            sorted_list.append(elm)
    return sorted_list

print(color_sort(critter_list, 'silver'))
