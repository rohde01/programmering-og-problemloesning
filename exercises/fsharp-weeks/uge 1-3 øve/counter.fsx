let counter () =
    let mutable a = 0 
    while a < 10 do
        a <- a + 1
        printfn "a = %A" a
counter ()

