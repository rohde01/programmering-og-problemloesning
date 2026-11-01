type vec = float * float

let vec1 = vec (2.0, 3.0)

let toInt(vec1: vec) : int int =
    (int(fst vec1), int(snd vec1))

let vecInt = toInt vec1

printfn "%A" vecInt