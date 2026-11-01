open CyclicQueue

[<EntryPoint>]
let main _ =
    create 4
    printfn "isEmpty = %A" (isEmpty ())
    dequeue 
    printfn "Empty queue dequeue test %A" (dequeue ()) 
    enqueue 4
    enqueue 8
    enqueue 25
    enqueue 26 
    printfn "isEmpty = %A" (isEmpty ())
    dequeue ()
    printfn "%A" (enqueue 1)
    enqueue 5
    toString ()
  
    // printfn "q test = %A" (getq())
    printfn "isEmpty test = %A" (isEmpty ())
    printfn "length test = %A" (length ())
    // printfn "Array.length test = %A" (Array.length (getq()))
    // printfn "enqueue test 1 = %A" (enqueue Value 3)
    // (or organize your tests into functions and call them from here)
    // Exit status; consider making it the number of failed tests
    0
