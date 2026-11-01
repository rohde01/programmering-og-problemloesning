from quiz2 import Qestion
question_prompts = [
    "what color is an apple? \n(a) \n(b) \n(c)\n\n", 
    "what color is a banana? \n(a) \n(b) \n(c)\n\n", 
    "what color is a avocado? \n(a) \n(b) \n(c)\n\n",
    "what color is a kiwi? \n(a) \n(b) \n(c)\n\n"
    ]

questions = [
Qestion(question_prompts[0], "a"),
Qestion(question_prompts[1], "c"),
Qestion(question_prompts[2], "b"),
Qestion(question_prompts[3], "b")
]

def run_test(questions):
    score = 0
    for question in questions:
        answer = input(question.prompt)
        if answer == question.answer:
            score += 1
    print("you scored " + str(score))
run_test(questions)

