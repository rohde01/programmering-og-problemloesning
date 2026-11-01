type vec = float * float 
 
let vec1 = vec(2.0, 3.0)

let toInt (v : vec) : int * int =
    (int(fst v), int(snd v))

let a = toInt vec1 

printfn "%A" a