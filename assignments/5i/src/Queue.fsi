module Queue

type queue<'a> = 'a list

/// <summary>creates an empty queue</summary>
/// <returns>An empty queue</returns>
val emptyQueue2: queue<'a>

/// <summary>puts an element on a queue and returns the resulting queue</summary>
/// <param name="elm"> an integer</param>
/// <param name="lst"> a queue</param>
/// <returns>the resulting queue</returns>
val enqueue2: 'a -> queue<'a> -> queue<'a>

/// <summary>checks if a queue is empty or not</summary>
/// <param name="lst">an element defined as a queue</param>
/// <returns>a true or false statement</returns>
val isEmpty2: queue<'a> -> bool

/// <summary>return the top element and the resulting queue</summary>
///<param name="lst"> a queue</param>
/// <returns>the top element and the resulting queue</returns>
val dequeue2: queue<'a> -> 'a * queue<'a>