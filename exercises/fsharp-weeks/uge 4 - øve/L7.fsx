let rec oneToN (n : int) : int list = 
    if n=0 then []
    else n :: oneToN (n-1)

let liste6 = oneToN 10
printfn "%A" liste6