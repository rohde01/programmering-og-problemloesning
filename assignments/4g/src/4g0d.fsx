/// Defines the position type as a tuple representing two coordinates. 
type pos = int * int 

/// Defines two coordinate tuples to test the functions.
let tuple1 = (3, 4)
let tuple2 = (1, 1)
printfn "Source coordinate = %A and target coordinate = %A" tuple1 tuple2

/// <summary>Calculates the distance between two coordinates using the formula 
/// distance = (x2 - x1)^2 - (y2 - y1)^2.</summary>
/// <param name="p1">The first position's coordinates.</param>
/// <param name="p2">The second position's coordinates.</param>
/// <returns>The distance as an integer.</returns> 
let dist (p1: pos) (p2: pos) : int =
    let inputInts = float(fst p2 - fst p1)**2.0 + float(snd p2 - snd p1)**2.0
    int(inputInts)

/// <summary> Creates a list of candidate movements by adding/subtracing 1 from 
/// each coordinate, then filters out any tuple whose distance is longer than
/// the distance between the source and target.</summary>
/// <param name="src">The source coordinate or starting position.</param>
/// <param name="tg">The target coordinate.</param>
/// <returns>A list of coordinate tuples.</returns>
let candidates (src: pos) (tg: pos) : pos list =
    let candPos = [fst src + 1, snd src] @ [fst src - 1, snd src] @ [fst src, snd src + 1] @ [fst src, snd src - 1] 
                @ [fst src + 1, snd src + 1] @ [fst src + 1, snd src - 1] @ [fst src - 1, snd src + 1] @ [fst src - 1, snd src - 1]
    List.filter (fun elm -> (dist elm tg) < (dist src tg)) candPos

/// <summary> Calls for a list of candidates at each recursive step. At each element,
/// the inner List.map calls candidates to receive a new candidate list closer to
/// the target. When it calls with a source identical to the target, the recursion stops.
/// All lists with more tuples than the shortest, are filtered out.  </summary>  
/// <param name="src">The source position.</param>
/// <param name="tg">The target position.</param>
/// <returns>A list with lists of coordinate tuples showing the shortest paths to the target. 
let rec routes (src: pos) (tg: pos) : pos list list =
    match src with 
        p when p = tg -> [[tg]]   
        | _ -> 
            let allRoutes = List.map (fun elm -> 
                            List.map (fun elm2 -> src::elm2) (routes elm tg)) (candidates src tg)
            let cons = List.concat allRoutes 
            let mapList = List.map (fun list -> List.length list) (cons)
            let minimum = List.min mapList
            let filter = List.filter (fun elm -> List.length elm = minimum) (cons)
            filter 
printfn "Shortest routes = %A" (routes tuple1 tuple2)

