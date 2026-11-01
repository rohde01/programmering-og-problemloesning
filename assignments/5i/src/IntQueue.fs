module IntQueue
type queue = int list

/// <summary>creates an empty queue</summary>
/// <returns>An empty queue</returns>
let emptyQueue:queue = []

/// <summary>checks if a queue is empty or not</summary>
/// <param name= "lst">an element defined as a queue</param>
/// <returns>a true or false statement</returns>
let isEmpty(lst:queue):bool = lst.IsEmpty

/// <summary>puts an element on a queue and returns the resulting queue</summary>
/// <param name= "elm"> an integer</param>
/// <param name="lst"> a queue</param>
/// <returns>the resulting queue</returns>
let enqueue (elm:int) (lst:queue):queue = lst @ [elm]

/// <summary>return the top element and the resulting queue</summary>
///<param name= "lst"> a queue</param>
/// <returns>the top element and the resulting queue</returns>
let dequeue (lst:queue):int*queue = (lst.Head, lst.Tail)