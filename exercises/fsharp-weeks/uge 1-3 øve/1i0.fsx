let rec input () =
    printfn "Please enter the name of a program"
    let a = (System.Console.ReadLine ())
    match a with
        |"fsharp" ->
          printfn "fsharp is cool"
          input ()
        |"quit"->
           ()
        | _ ->
          printfn "I don't know: %A" a
          input ()

input()
