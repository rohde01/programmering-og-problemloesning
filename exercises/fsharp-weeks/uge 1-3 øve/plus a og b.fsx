let sum x y = x + y
printfn "plus a og b"
printf "indtast a: "
let a = int (System.Console.ReadLine ())
printf "indtast b: "
let b = int (System.Console.ReadLine ())
let c = sum a b
do printfn "%A" c;;


