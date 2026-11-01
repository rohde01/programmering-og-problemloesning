//open IntQueue
//open Queue
//open SafeIntQueue

printfn "IntQueue"

let intQueueTests() =
    let q0 = IntQueue.emptyQueue
    let emptyTestResult = IntQueue.isEmpty q0
    emptyTestResult
    |> printfn "An empty queue is empty : %A"

    let e1,e2,e3 = 1,2,3
    let q1 = q0 |> IntQueue.enqueue e1
                |> IntQueue.enqueue e2
                |> IntQueue.enqueue e3
    let nonEmptyTestResult = not (IntQueue.isEmpty q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty : %A"

    let (e,q2) = IntQueue.dequeue q1
    
    let dequeueTestResult = e = e1
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResult

    // Return the test results as a boolean
    allTestResults
    |> printfn "All IntQueue tests passed: %A"
    

let intQueueTestResults = intQueueTests()

printfn "---------------------------------------------"
printfn "                   SafeIntQueue"


let safeIntQueueTests() =
    let q0 = SafeIntQueue.emptyQueue
    let emptyTestResult = SafeIntQueue.isEmpty q0
    emptyTestResult
    |> printfn "An empty queue is empty : %A"

    let e1,e2,e3 = 1,2,3
    let q1 = q0 |> SafeIntQueue.enqueue e1
                |> SafeIntQueue.enqueue e2
                |> SafeIntQueue.enqueue e3
    let nonEmptyTestResult = not (SafeIntQueue.isEmpty q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty : %A"

    let e = SafeIntQueue.dequeue q0
    let dequeueTestResultNone = e = (None,[])
    dequeueTestResultNone
    |> printfn "First in is first out (None): %A"

    let (e4,q2) = SafeIntQueue.dequeue q1
    let dequeueTestResult = e4 = Some(e1)
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResultNone &&
        dequeueTestResult

    // Return the test results as a boolean
    allTestResults|> printfn "All SafeIntQueue tests passed: %A"


let safeintQueueTestResults = safeIntQueueTests()

printfn "---------------------------------------------"
printfn "                   QueueTest"

// queuetest med generisk input
let QueueTests(e1:'a)(e2:'a)(e3:'a) =
    let q0 = Queue.emptyQueue2
    let emptyTestResult = Queue.isEmpty2 q0
    emptyTestResult
    |> printfn "An empty queue is empty : %A"

    let q1 = q0 |> Queue.enqueue2 e1
                |> Queue.enqueue2 e2
                |> Queue.enqueue2 e3
    let nonEmptyTestResult = not (Queue.isEmpty2 q1)

    nonEmptyTestResult
    |> printfn "A queue with elements is not empty : %A"

    let (e,q2) = Queue.dequeue2 q1
    
    let dequeueTestResult = e = e1
    dequeueTestResult
    |> printfn "First in is first out: %A"

    let allTestResults =
        emptyTestResult &&
        nonEmptyTestResult &&
        dequeueTestResult

    // Return the test results as a boolean
    allTestResults
    |> printfn "All Queue tests passed: %A"
    

// queue test
printfn "Floats"
let TestResultFloat = (QueueTests(1.6)(4.2)(8.0))
printfn "----------------------------------------"
printfn "Integer"
let TestResultInterger = (QueueTests(1)(3)(7))
printfn "-----------------------------------------"
printfn "String"
let TestResultString = (QueueTests("5")("_")("C-E"))