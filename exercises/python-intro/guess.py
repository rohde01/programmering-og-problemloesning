secret_word = "test"
guess = ""
attempts = 0
done = False


while guess != secret_word and not done:
    if attempts < 5:
        guess = input("Guess the secret word: ")
        attempts += 1
    else:
        done = True

if done:
    print("You lost - out of attempts")
else:
    print("you won!")
