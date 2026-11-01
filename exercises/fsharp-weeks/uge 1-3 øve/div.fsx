let div x y = x ** y
printfn "divider a og b"
printf "indtast a: "
let a = int (System.Console.ReadLine ())
printf "indtast b: "
let b = int (System.Console.ReadLine ())
match b with
0 -> do printfn "HAHAHAH TABER"
| _ ->
let c = div a b
do printfn "%A" c;;
