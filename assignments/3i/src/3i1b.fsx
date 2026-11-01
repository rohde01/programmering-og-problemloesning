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
    let rnd = System.Random()
    let a = rnd.Next 400 
    let b = rnd.Next 250 
    [PenUp; Turn (a); Move (b); Turn -(a); PenDown] @ (tree (str))@[PenUp; Turn (a);Move -(b); Turn -(a) ]

//Udvidelse af programmet, der tegner en skov ved at placere flere træer i canvas 

///<summary> En funktion der x-antal gange gentager processen fra ovenstående programmer </summary>
///<param name="str"> Størrelse på træerne </param>
///<param name="x"> antallet af træer </param>
///<returns> turtleCmd's til en tegning i canvas med x-antal træer </returns>
let rec forest (str:int) (x:int) :Canvas.turtleCmd list =
    match x with
        |0 ->[]
        |_->(forest str (x-1))@(randomTree str)

let str =125
let w=600
let h=600 


turtleDraw (w,h) "stor stor skov wooow"  (forest str 10)
