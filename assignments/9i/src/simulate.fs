module simulate

type drone (position : (int * int), speed : int, destination : (int * int), name : string) =
    
    let vec2 = position 
    let mutable pos = position
    let spe = speed
    let dest = destination
    let mutable direction = 0.0
    let mutable crashed = false 
    
    member this._crashed = crashed 
    member this.crash () = crashed <- true 
    member this.getPosition = pos
    member this.getSpeed = spe
    member this.getDestination = dest
    
/// <summary>Makes a drone fly towards its destination for 1 second</summary>
/// <returns>The drone with updated coordinates</returns>
    member this.fly () = 
        direction <- atan2 (float(snd dest - snd pos)) (float(fst dest - fst pos))
        
        let x = (float(speed) * (System.Math.Cos (direction)) |> int)
        let y = (float(speed) * (System.Math.Sin (direction)) |> int)
        pos <- (fst pos + x, snd pos + y)

/// <summary>Checks if a drone has reached its destination</summary>
/// <returns>"True" if at destination, otherwise "false"</returns>         
    member this.AtDestination =
        let retning = System.Math.Sqrt((float(fst vec2 - fst pos) ** 2) + (float(snd vec2 - snd pos) ** 2))
        let retning2 = System.Math.Sqrt((float(fst dest - fst vec2) ** 2) + (float(snd dest - snd vec2) ** 2))
        if retning >= retning2 then 
            pos <- (fst dest, snd dest)
            printfn "true"
        else printfn "false"

/// <summary> makes the information contained public </summary>
/// <param name= "name"> the name of the drone</param>
/// <returns>the name of the drone</returns>
    override this.ToString() = 
        name 

type airspace () =
    let mutable drones = []
    let mutable list = []

/// <summary>Calculates the distance between two given drones</summary>
/// <param name= "firstDrone"> the first drone</param>
/// <param name= "secondDrone"> the second drone</param>
/// <returns>The distance between the drones</returns>
    member this.DroneDist (firstDrone : drone) (secondDrone : drone) = 
        let dist = System.Math.Sqrt((float(fst firstDrone.getPosition - fst secondDrone.getPosition) ** 2) + (float(snd firstDrone.getPosition - snd secondDrone.getPosition) ** 2)) 
        dist

/// <summary> Returns the current collection of drones</summary>
/// <returns>The current collection of active drones</returns>
    member this.getDrones() = drones

/// <summary> adds a drone to the collection of drones</summary>
/// <param name= "drone"> the drone to be added</param>
/// <returns>nothing</returns>
    member this.add (drone : drone) = drones <- drone :: drones 

    override this.ToString () = drones.ToString()

/// <summary> makes alle drones in the collection fly for 1 second</summary>
/// <returns> the updated drone list </returns>
    member this.FlyDrones () =
        let flownDrones = drones |> List.iter (fun (drone : drone) -> drone.fly())
        flownDrones

/// <summary> determines what drones will collide, and removes them from the collection </summary>
/// <returns> the updated collection of drones</returns>
    member this.collide () =
        let mutable collisions = []
        for i in 0..(drones.Length - 1) do 
            for h in 0..drones.Length - 1 do 
                if i = h then ()
                else
                let drone1 = drones.[i]
                let drone2 = drones.[h]
                if (this.DroneDist drone1 drone2) < 5.0 then 
                    collisions <- (drone1, drone2) :: collisions 
                    drone1.crash ()
                    drone2.crash ()

        drones <- List.filter (fun d -> not d._crashed) drones 
        collisions


type Assert () = 
    static member asserttest (string: string) (a: 'a) (b: 'b) (f: ('a -> 'b -> bool)) : unit =
        match f a b with 
            true -> printfn "Pass: %s" string
            | _ -> printfn "error: %s" string
