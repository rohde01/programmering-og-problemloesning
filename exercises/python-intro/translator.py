#oversætteren ændrer alle vokaler til et g
def translate(phrase):
    translation = ""
    for letter in phrase:
        if letter in "aeiouyæøåAEIOUYÆØÅ":
            translation = translation + "g"
        else:
            translation = translation + letter
    return translation

print(translate(input("indtast en sætning der skal oversættes: ")))
