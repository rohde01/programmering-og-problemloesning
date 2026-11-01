#r "nuget:DIKU.Canvas, 1.0.1"

open Canvas

let w = 700
let h = 700
let C = create w h

type vec = float * float 
 
let vec1 = vec(2.0, 3.0)

let toInt (v : vec) : int * int =
    (int(fst v), int(snd v))

let a = toInt vec1 

printfn "%A" a

let add (vec1: vec) (vec2: vec) : vec =

    vec(fst vec1 + fst vec2, snd vec1 + snd vec2)

let setVector (can: canvas) (col: color) (a: vec) (b: vec): unit =
    setLine can col (toInt a) (toInt(add a b))

setVector C blue (300.0,250.0) (100.0,300.0)

show C "p to p+v"
