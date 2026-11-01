#10ø1
class Person:
    def __init__(self, name, address, phone):
        self.name = name
        self.address = address
        self.phone = phone

class Customer(Person):
    def __init__(self, name, address, phone, customer_number, mailing_list):
        super().__init__(name, address, phone)
        self.customer_number = customer_number
        self.mailing_list = mailing_list

# Create a Customer object
customer = Customer("Alice Smith", "123 Main St", "555-555-1212", 12345, True)

# Print the customer's name, address, and phone number
print(customer.name)
print(customer.address)
print(customer.phone)

# Print the customer's customer number and mailing list preference
print(customer.customer_number)
print(customer.mailing_list)
