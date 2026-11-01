#r "nuget:DIKU.Canvas, 1.0"
open Canvas
let w = 600;
let h = 400;
let C = create w h
    let left = w / 4
    let right = 3*left
    do setFillBox C black (left+s, left) (right+s,right)
do show C "MyFirstCanvas"