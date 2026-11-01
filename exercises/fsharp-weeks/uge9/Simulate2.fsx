type drone (position : (int * int), speed : int, destination : (int * int)) =
    
    //constructor
    let mutable pos = position
    let mutable spe = speed
    let mutable dest = destination
    //member
    member this.getPosition = pos
    member this.getSpeed = spe
    member this.getDestination = dest
    //method
    member this.fly = 
        let retning = System.Math.Tan ((snd dest - snd pos / fst dest - fst pos) |> float)
        let x = speed * System.Math.Cos ((retning) |> float)
        let y = speed * System.Math.Sin ((retning) |> float)
        pos <- ((x, y) |> int)
    member this.AtDestination =
        if pos = dest then printfn "true" else printfn "false"

let drone1 = drone ((0, 0), 15, (10, 10))

printfn "Start position: %A" drone1.getPosition
drone1.fly
printfn "Sktuelle position: %A" drone1.getPosition
drone1.AtDestination