type vec = float * float

let vec1 = vec (1.0, 2.0)
let vec2 = vec (3.0, 4.0)
let add (vec1: vec) (vec2: vec) : vec =

    vec(fst vec1 + fst vec2, snd vec1 + snd vec2)

let vec3 = add vec1 vec2
printfn "%A" vec3