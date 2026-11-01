#r "nuget:diku.canvas, 1.0.1"
open Canvas


//tegneprogram fra opgavebeskrivelsen (Figur1)

///<summary> Laver en liste af turtleCmd's, som bruges til at tegne et træ. </summary>
///<param name="str"> Størrelsen på træet </param>
///<returns> En tegning af et træ i canvas </returns>
let rec tree (str: int) :Canvas.turtleCmd list =
    if str < 5 then
        [Move str; PenUp; Move (-str); PenDown]
    else
        [Move (str/3); Turn -30]
        @ tree (str*2/3)

        @ [Turn 30; Move (str/6); Turn 25]
        @ tree (str/2)
        @ [Turn -25; Move (str/3); Turn 25]
        @ tree (str/2)
        @ [Turn -25; Move (str/6)]
        @ [PenUp; Move (-str/3); Move (-str/6); Move (-str/3)]
        @ [Move (-str/6); PenDown]


//Udvidelse af ovenstående program, der placerer træet et tilfældigt sted på canvas 

///<summary> En funktion der tegner et træ  </summary>
///<param name="str"> Størrelsen på træet </param>
///<returns> Tilfældige turtleCmd's, som tegner træet et tilfældigt sted på canvas  </returns>
let randomTree (str: int) :Canvas.turtleCmd list= 
    let tilfældig = System.Random()
    let a = tilfældig.Next 400 
    let b = tilfældig.Next 250 
    [PenUp; Turn (a); Move (b); Turn -(a); PenDown] @ (tree (str))@[PenUp; Turn (a);Move -(b); Turn -(a) ]
    
let w = 600
let h = 600
let str = 125

turtleDraw (w,h) "Tilfældigt træ" (randomTree str)




