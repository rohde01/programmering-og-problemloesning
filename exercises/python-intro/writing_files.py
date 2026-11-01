#"a" står for append, og betyder at man åbner filen for at tilføje noget til slutningen af filen
#"w" står for write, og vil i stedet overskrive alt i filen med det nye tekst
test_file = open("test.txt", "a")

#tilføj tekst til filen. \n laver linjeskift 
test_file.write("\ntest 5")

test_file.close()