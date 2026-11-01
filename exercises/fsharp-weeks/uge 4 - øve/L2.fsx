let lst = [2..3]
let lst2 = [4..6]

printfn "%A" (lst @ lst2)

let lst3 = [4] @ [5]
printfn "%A" lst3


let lst4 = lst @ lst2

printfn "%A" lst4

