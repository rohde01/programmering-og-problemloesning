#9ø0 // 9ø1
# class Student:
#     def __init__(self, name):
#         self.name = name
#     def set_name(self, new_name):
#         self.name = new_name

# # Create two Student objects
# student1 = Student("Alice")
# student2 = Student("Bob")

# student1.set_name("Emil")

# # Print the name of each student
# print(student1.name)
# print(student2.name)

# #9ø4 
# class Counter:
#     def __init__(self):
#         self.counter = 0
#     def get(self):
#         return self.counter
#     def incr(self):
#         self.counter += 1

# # Create a Counter object
# counter = Counter()
# # Print the current value of the counter
# print(counter.get())
# # Increment the counter
# counter.incr()
# # Print the current value of the counter again
# print(counter.get())

#9ø5
class Car:
    def __init__(self, econ, fuel):
        self.econ = econ
        self.fuel_left = fuel
        print(f"Created a car ({econ:.1f}, {fuel:.1f})")
    
    def drive(self, distance):
        self.fuel_left -= self.econ * distance / 100.0
    
    def add(self):
        self.fuel_left += 30.0

sport = Car(8.0, 60.0)
economy = Car(5.0, 45.0)
sport.drive(200.0)
economy.add()
print("Fuel left after 100km driving:")
print(f" sport: {sport.fuel_left}")
print(f" economy: {economy.fuel_left}")





