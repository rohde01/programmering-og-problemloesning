printfn "Indtast heltal"
let rec fac1 n =
    match n with
        0 -> 1
        |_ -> n * fac1(n-1)

let n = int (System.Console.ReadLine())
let answer = fac1 n
printfn "%A" answe