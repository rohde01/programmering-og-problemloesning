let rec oneToN (n : int) : int list = 
    if n = 0 then []
    else oneToN (n-1) @ [n]

let liste6 = oneToN 10
printfn "%A" liste6





