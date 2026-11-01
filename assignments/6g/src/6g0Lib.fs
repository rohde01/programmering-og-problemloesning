module m2048 
open Canvas 

type pos = int*int // A 2-dimensional vector in board-coordinates (not pixels)
type value = Red | Green | Blue | Yellow | Black // Piece values
type piece = value*pos //
type state = piece list // The board is a set of randomly organised pieces 

// Convert a 2048-value v to a canvas color.
/// <summary> Turns a color value into a Canvas.color. </summary>
/// <param name="v"> A color value </param> 
/// <returns> A Canvas color value. </returns>
let fromValue (v: value) : Canvas.color = 
    match v with 
    | Red -> Canvas.red 
    | Green -> Canvas.green 
    | Blue -> Canvas.blue 
    | Yellow -> Canvas.yellow 
    | Black -> Canvas.black 

// Give the 2048-value which is the next in order. 
/// <summary> Turns a color into the new color when merging pieces. </summary>
/// <param name="c"> The color value. </param> 
/// <returns> A new Canvas color value. </returns>
let nextColour (c: value) : value =
    match c with 
        Red -> Green 
        | Green -> Blue 
        | Blue -> Yellow 
        | Yellow -> Black
        | Black -> Black  

// Return the list of pieces on a column k on board s. 
/// <summary> Filters a piece list according to column. </summary>
/// <param name="k"> The column number. </param> 
/// <param name="s"> A state. </param>
/// <returns> A piece list with only the pieces in the given column number </returns>
let filter (k: int) (s: state) : state = 
    List.filter (fun (v, (x, y)) -> y=k) s 

/// <summary> Sorts a piece list according to row (x coordinate). </summary>
/// <param name="s"> A board state. </param>
/// <returns> A board state with pieces sorted by row </returns>
let sortRow (s: state) : state =
    List.sortBy (fun (v, (x,y)) -> x) s 

// Faktisk "shiftLEFT"
/// <summary> Matches a piece list with a pattern and moves the pieces. </summary> 
/// <param name="s"> A state. </param>
/// <returns> A piece list sorted according to column and row with appropriate
/// pieces merged. </returns>
let shiftUp (s: state) : state =
    let helper (a: state) : state = 
        match a with 
        [(v, (x,y))] -> [(v, (0, y))]

        | (v2, (x2, y2)) :: [(v3, (x3,y3))] ->
            if v2 = v3 then [(nextColour v2, (0, y2))]
            else [(v2, (0, y2)); (v3, (1, y2))] 

        | (v4, (x4, y4)) :: (v5, (x5, y5)) :: [(v6, (x6, y6))] -> 
            if v4 = v5 then [(v6, (1, y5))] @ [(nextColour v4, (0,y4))]
            elif v5 = v6 then [(v4, (0, y4))] @ [(nextColour v5, (1, y4))]
            else [(v4, (x4, y4)) ; (v5, (x5, y5)) ; (v6, (x6, y6))] 
        | _ -> [] 

    // let sort = List.sortBy (fun (_, (r, _)) -> r)
    // let a = s |> filter 0 |> sort |> helper
    // let b = s |> filter 1 |> sort |> helper 
    // let c = s |> filter 2 |> sort |> helper 
    // a@b@c 

    let sort1 = s |> filter 0 |> sortRow |> helper 
    let sort2 = s |> filter 1 |> sortRow |> helper 
    let sort3 = s |> filter 2 |> sortRow |> helper 
    sort1 @ sort2 @ sort3

/// <summary> Flip the board s such that all pieces' position change as 
/// (i,j) -> (2-i,j). </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A state with all the pieces x coordinates changed. </returns> 
let flipUp (s: state) : state = 
    List.map (fun (v, (x,y)) -> (v, (2-x,y))) s 

/// <summary> Flip the board s such that all pieces' position change as 
/// (i,j) -> (2-i,j). </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A state with all the pieces x coordinates changed. </returns>
let transpose (s: state) : state = 
    List.map (fun (v, (x,y)) -> (v, (y,x))) s 

/// <summary> Find the list of empty positions on the board. </summary> 
/// <param name="s"> A board state. </param>
/// <returns> A list with the empty positions. </returns> 
let empty (s: state) : pos list = 
    let allPossible = [(0,0); (0,1); (0,2); (1,0); (1,1); (1,2); (2,0); (2,1); (2,2)] 
    let coordList = List.map (fun (v, (x,y)) -> (x,y)) s // -> Liste kun med brikkers koordinater  
    List.except coordList allPossible 

/// <summary> Adds a random red piece to the board on an empty position. </summary> 
/// <param name="c"> Color value. </param>
/// <param name="s"> Board state. </param>
/// <returns> The state list with a random piece added. </returns>
let rnd = System.Random() 
let rec addRandom (c: value) (s: state): state option = 
    let rndPiece = (rnd.Next 3, rnd.Next 3) 
    if List.length s = 9 then None 
    elif List.exists (fun (a, b) -> (a, b) = rndPiece) (empty s) then Some ((c, rndPiece) :: s)
    else addRandom c s

/// <summary> Draws the canvas and pieces. </summary> 
/// <param name="w"> Width of the canvas. </param>
/// <param name="h"> Height of the canvas. </param>
/// <param name="s"> The board state. </param>
/// <returns> The canvas with all pieces drawn. </returns>
let draw (w: int) (h: int) (s: state) : canvas =
    let C = create w h 
    List.map (fun (v, (x,y)) -> do setFillBox C (fromValue v) (x * h/3, y * w/3) ((x+1) * h/3, (y+1) * w/3)) s
    C
/// <summary> Changes the board according to arrow keys. </summary> 
/// <param name="s"> The board state. </param>
/// <param name="k"> The input arrow key. </param>
/// <returns> The re-arranged board. </returns>
let react (s: state) (k: key) : state option =
    match getKey k with
        | LeftArrow ->
            addRandom Red (shiftUp s)
        | RightArrow ->
            flipUp s |> shiftUp |> flipUp |> addRandom Red
        |UpArrow ->
            transpose s |> shiftUp |> transpose |> addRandom Red
        |DownArrow ->
            transpose s |> flipUp |> shiftUp |> flipUp |> transpose |> addRandom Red

let board = (addRandom Red []).Value   
// do runApp "2048" 600 600 draw react board

/// Tests 
let testState1 = [(Green, (1, 0)); (Yellow, (2,1))]
printfn "shiftUp: %A" (shiftUp testState1) 
printfn "flipUp: %A" (flipUp testState1) 
// printfn "transpose: %A" (transpose testState1)
// printfn "empty: %A" (empty testState1) 
// printfn "addRandom: %A" (addRandom Red testState1)  
    






