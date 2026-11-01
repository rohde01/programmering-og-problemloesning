#r "nuget:diku.canvas, 1.0.1"
open Canvas
type move = int*int // et talpar af "turn" og "move"
let lst = [(10, 30); (-5, 127); (20, 90)]

//Første funktion (Rec)

/// <summary> Konverterer en liste af talpar, til en ny liste med of turtleCmd's </summary>
/// <param name="lst"> En liste af talpar (moves) </param>
/// <returns> En liste med turtleCmd's</returns>
let rec move (n: move list) : Canvas.turtleCmd list = 
    match n with
        [] -> []
        |_->
            [(Turn (fst n.Head)); (Move (snd n.Head))] @ (move n.Tail)
printfn "%A" (move lst)


//Anden funktion (Map)

/// <summary> Konverterer en liste af talpar, til en ny liste med of turtleCmd's </summary>
/// <param name="lst"> En liste af talpar (moves) </param>
/// <returns> En liste med turtleCmd's</returns>
let move2 (n: move list) : Canvas.turtleCmd list =
    let map = List.map (fun n -> ([Turn (fst n); Move (snd n)])) lst
    List.concat map
printfn "%A" (move2 lst)


//Tredje funktion (Fold)

/// <summary> Konverterer en liste af talpar, til en ny liste med of turtleCmd's </summary>
/// <param name="lst"> En liste af talpar (moves) </param>
/// <returns> En liste med turtleCmd's</returns>
let move3 (n: move list) : Canvas.turtleCmd list =
    let fold = (List.fold (fun i (x,y) -> Move(y):: Turn(x):: i) [] n)
    List.rev fold
printfn "%A" (move3 lst)


//Fjerde funktion (Foldback)

/// <summary> Konverterer en liste af talpar, til en ny liste med of turtleCmd's </summary>
/// <param name="lst"> En liste af talpar (moves) </param>
/// <returns> En liste med turtleCmd's</returns>
let move4 (n: move list) : Canvas.turtleCmd list =
    let foldback = (List.foldBack (fun (x,y) i -> Turn(x) :: Move(y) :: i) n [])
    foldback
printfn "%A" (move4 lst)

