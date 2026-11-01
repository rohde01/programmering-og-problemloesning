
def create_critter(name, color, point):
    critter = {'name': name, 'color': color, 'point': point}
    return critter

def get_name(critter):
  return critter['name']

def get_color(critter):
  return critter['color']

def get_point(critter):
  return critter['point']

def hit_point(critter, hit):
    critter['point'] = get_point(testCritter) - hit


testCritter = create_critter("test", "blue", 10)

print(testCritter)

# hit_point(testCritter, 7)

# print(get_name(testCritter))
# print(get_color(testCritter))
# print(get_point(testCritter))