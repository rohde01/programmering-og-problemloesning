let rec counter a = 
    match a with 
        11 -> 
            printfn "Færdig"
        | _ ->
            printfn "a = %A" a 
            counter (a + 1)

counter 1