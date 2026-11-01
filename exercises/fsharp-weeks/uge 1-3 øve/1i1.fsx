#r "nuget:DIKU.Canvas, 1.0"
open Canvas

type state = int

let draw w h (s:state) =
  let C = create w h
  let left = w / 4
  let right = 3*left
  do setFillBox C black (left+s, left) (right+s,right)
  do setLine C black (0,0) (left+s, left)
  do setLine C black (w-1,h-1) (right+s,right)
  do setLine C black (0,600) (left+s,right)
  do setLine C black (600,0) (right+s,left)

  C

let react (s:state) (k:key) : state option =
    match getKey k with
        LeftArrow -> Some (s-5)
        | RightArrow -> Some (s + 5)
        | _ -> None

do runApp "ColorBoxes" 600 600 draw react 0
