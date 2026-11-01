module CyclicQueue

type Value = int

let mutable q : Value option[] = [||]
let mutable first : int option = None
let mutable last : int option = None 

let create (n: int) : unit =
    q <- Array.create n None
    first <- None 
    last <- None 

let isEmpty () : bool =
    if (first, last) = (None, None) then true
    else false  

let length () : int =
    let mutable len = 0
    for i in q do 
        match i with 
        | Some x -> (len <- len + 1)
        | None -> () 
        // printfn "Length output test = %A" (len)
    len

let enqueue (e: Value) : bool =
    // Tests the first case where q is empty.
    if isEmpty() then 
        first <- Some(0) 
        q[first.Value] <- Some(e)
        last <- Some(0)
        q[last.Value] <- Some(e)
        true 

    // Tests the second case where q is neither empty nor full: meaning 
    // the "length of Some x elements" =/= q's array length (fixed storage). 
    // including empty spaces.
    elif (<>) (length()) (Array.length q) then 

        if last.Value = (q.Length - 1) then
            last <- Some(0) 
            q[last.Value] <- Some(e)
            true 
        
        else 
        last <- Some(last.Value+1)
        q[last.Value] <- Some(e) 
        true 

    else 
        printfn "Queue is full. Dequeue an element to free up space."
        false   

let dequeue () : Value option =
    // Conditional catches dequeuing from empty queue errors
    if first = None then 
        None

    else 
        let dequeued = q[first.Value]
        q[first.Value] <- None

        if first.Value = q.Length-1 then
            first <- Some(0)    
        else
            first <- Some(first.Value+1) 

            printfn "dequeue first test = %A" first 
            printfn "dequeue value test = %A" (q[first.Value])

        printfn "dequeue return test = %A" (dequeued)
        dequeued   

let toString () : string =
    let mutable arrayString = ""
    for i in q do 
        match i with 
        | Some x -> 
            arrayString <- arrayString + string(x) + "," + " "
        | None -> () 
    let len = String.length arrayString
    let print = arrayString[0..(len-3)]
    printfn "Queue string = %s" print 
    print 

