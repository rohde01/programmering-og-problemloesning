# Opgave A

class AddConst:
    """Finder summen af to tal."""
    def __init__(self, c):
        self._c = c 

    def get_c(self) -> str:
        return self._c 
    
    def apply(self, x):
        return x + self._c 

    def description(self) -> str:
        return self.__doc__.lower() 

class Repeater:
    """ Tager et tal num og opretter en
    liste med num antal elementer. apply()
    indsætter et element x på alle listelementer. 
    """
    def __init__(self, num: int):
        self._num = num 
    
    def apply(self, x):
        if self._num == 0:
            return []
        else:
            return [x] * self._num 
    
    def description(self) -> str:
        return self.__doc__.lower() 

import operator 

class GeneralSum:
    """ Tager et neutralt element og en operator.
    apply() tager en iterable og returnerer summen,
    når operatoren udføres på hvert element.
    """
    def __init__(self, neutral, operator):
        self._neutral = neutral 
        self._operator = operator 

    def get_values(self):
        return ('neutral = ' + str(self._neutral) 
        + ' og operator = ' + str(self._operator))

    def apply(self, iterable):
        result = self._neutral 
        for x in iterable:
            result = self._operator(result, x)
        return result 
    
    def description(self) -> str:
        return self.__doc__.lower()

class SumNum(GeneralSum):
    """Kalder GeneralSum() med neutral = 0 og +-operator."""
    def __init__(self) -> None:
        super().__init__(0, operator.add)

    def description(self) -> str:
        return self.__doc__

class ProductNum(GeneralSum):
    """ Kalder GeneralSum() med neutral = 1 og
    *-operator.
    """
    def __init__(self) -> None:
        super().__init__(1, operator.mul)

    def description(self) -> str:
        return self.__doc__.lower()

# Opgave B
class Map:
    """Tager en Step funktion som input. apply() bruger 
    Step på en iterable og returnerer en liste med resultaterne.
    """
    def __init__(self, step):
        self._step = step
        self.akkumulator = []

    def apply(self, iterable):
        for elm in iterable:
            y = self._step.apply(elm)
            self.akkumulator.append(y)
        return self.akkumulator
    def description(self) -> str:
        return self.__doc__

#Opgave C
class Pipeline:
    """ Tager en liste af Steps og fører resultatet 
    af hvert Step videre ind det næste Step. 
    Returnerer det endelig resultat.  
    """
    def __init__(self, step_list): 
        self._step_list = step_list
    
    def apply(self, n):
        result = n  
        for elm in self._step_list:
            result = elm.apply(result) 
        
        return result 

    def add_step(self, step):
        self._step_list.append(step)

    def description(self) -> str: 
        return self.__doc__

#Opgace E
class Square:
    """Udregner kvadratroden af input (num)"""
    def __init__(self, num):
        self.num = num
    def apply(self):
        return self.num * self.num
    def description(self):
        return self.__doc__

class Cube:
    """Udregner kubikroden af input (num)"""
    def __init__(self, num):
        self.num = num
    def apply(self):
        return self.num * self.num * self.num
    def description(self):
        return self.__doc__

class Sort:
    """Sorterer input (en liste), på en af to måder alt efter om det er en int eller string list"""
    def __init__(self, my_list):
        self.my_list = my_list
    def sort_(self):
        return sorted(self.my_list)
    def description(self):
        return self.__doc__

# Opgave D 
import csv

class CsvReader:
    """ Reads the critters csv file and returns
    a list with dictionaries for each creature.
    """
    def __init__(self, filename):
        self._filename = filename 

    def apply(self):
        critter_data = []
        with open(self._filename, newline='') as csvfile:
            data_reader = csv.DictReader(csvfile) 
            for row in data_reader:
                critter_data.append(row)
        return critter_data 
    
    def description(self):
        return self.__doc__

critter_data = CsvReader('critters.csv')
critter_apply_data = critter_data.apply()

class CritterStats:
    """Creates a dictionary with critter colours
    as keys and how many times a colour appears.
    """
    def __init__(self, filename):
        self._critter_data = filename
 

    def apply(self): 
        colour_dict = {}
        for critter in critter_apply_data: 
            if critter['Colour'] in colour_dict: 
                colour_dict[critter['Colour']] += 1 
            else: colour_dict[critter['Colour']] = 1 
        return colour_dict
    
    def description(self):
        return self.__doc__

class ShowAsciiBarchart:
    """Creates a dictionary with critter colours
    as keys and how many times a colour appears.
    """
    def __init__(self, filename):
        self._critter_data = filename
 
    def apply(self): 
        Ascii_bars = {}
        for critter in critter_apply_data: 
            if critter['Colour'] in Ascii_bars: 
                Ascii_bars[critter['Colour']] += '*'
            else: Ascii_bars[critter['Colour']] = '*' 
        for elm in Ascii_bars:
            print(elm, ' ' , Ascii_bars[elm])
    
    def description(self):
        return self.__doc__