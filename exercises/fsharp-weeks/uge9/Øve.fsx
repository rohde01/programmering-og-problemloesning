//9ø1
(*
*)
type student (aName : string, a : int) =
    // Constructor body section
    let mutable name = aName // liters in the tank

    do printfn "Created a student (%A)" aName

    // Member section
    member this.getValue() = name
    // Method
    member this.setValue newName =
        name <- newName
    member this.age = a
// laver nye studerende:
let student1 = student ("Emil", 10)
let student2 = student ("Christer", 45)

//student1.getValue()
student2.setValue ("Christian")

printfn " student1: %A" (student1.getValue())
printfn " student2: %A" (student2.getValue())
printfn " student2: %A" (student2.age)
// printfn " economy: %A" economy.aName

//9ø2
type student (aName : string, a : int) =
    // Constructor body section
    let mutable namee = aName

    // Member section
    member this.name
        with get() = namee
        and set (m) = namee <- m
    // Method
    member this.age = a

    override this.ToString() = "Name = " + aName

// laver nye studerende:
let student1 = student ("Emil", 10)
let student2 = student ("Christer", 45)


printfn " .%s" student1.name 
student1.name <- "Christian"
printfn " .%s" student1.name
printfn "override test %s" (student2.ToString())

//9ø3
type student(n: string) =
    let mutable _name = n
    member this.name
        with get() = _name
        and set(m)= _name <- m
    member this.clone () = student (this.name)
    override this.ToString () = _name

let a = student("Jon")
let b = a
let c = b.clone()
b.name <- "Mads"
printfn "a=%A\nb=%A\nc=%A" a b c

//9ø4

type counter (n: int) =
    let mutable number = n
    member this.get with get() = number
    member this.incr = number <- number + 1

let a = counter 5

printfn "test %A" (a.get)
a.incr
printfn "test %A" (a.get)

//9ø5
type car (econ : float, fuel : float) =
    // Constructor body section
    let mutable fuelLeft = fuel // liters in the tank
    do printfn "Created a car (%.1f, %.1f)" econ fuel
    // Member section
    member this.fuel = fuelLeft
    member this.drive distance =
        fuelLeft <- fuelLeft - econ * distance / 100.0
    member this.add = fuelLeft <- fuelLeft + 30.0

let sport = car (8.0, 60.0)
let economy = car (5.0, 45.0)
sport.drive 200.0
economy.add
printfn "Fuel left after 100km driving:"
printfn " sport: %A" sport.fuel
printfn " economy: %A" economy.fuel

//9ø6
type lamp (moth : (float * float)) =
    //constructor
    let mutable pos = moth
    //member section
    member this.getPosition = pos 
    member this.moveToLight =
        pos <- (fst pos / 2.0, snd pos / 2.0)

let moth1 = lamp (20.0, 35.0)

printfn "start position: %A" moth1.getPosition
// moth1.moveToLight
// printfn "Halvejs mod lyset: %A" moth1.getPosition

