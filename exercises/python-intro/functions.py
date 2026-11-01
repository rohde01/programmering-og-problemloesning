
#Man definerer en funktion med keyworded "def"
def sayhi(name, age ): #funktionens parametre er defineret i parantesen, altså det man skal give funktionen for at den kører
    print("hello " + name + " you are " + str(age))
sayhi("Carl-Emil", 21) #kalder funktionen 

#return statements returnerer information fra en funktion
def potens(num):
    return num*num*num
resultat = potens(3)
print(resultat)

#if-statements eksekverer et stykke kode, hvis en bestemt betingelse er opfyldt
is_male = False
is_tall = True
#alt indrykket kode efter kolon, bliver kørt alt efter true eller false
if is_male and is_tall: 
    print("Du er en høj mand")
elif is_male and not is_tall:
    print("du er en lav mand")
elif is_tall and not is_male:
    print("du er en høj kvinde")
else:
    print("Du er en kvinde og lav")
 
#if-statements og sammenligninger. printer det højeste tal
def max_num(num1, num2, num3):
    if num1 > num2 and num1 > num3:
        return num1
    elif num2 > num1 and num2 > num3:
        return num2
    elif num3 > num2 and num3 > num1:
        return num3
print(max_num(10, 300, 40))

#man kan også sammenligne strings med if-statements ved brug af ==. != betyder ikke lig med
