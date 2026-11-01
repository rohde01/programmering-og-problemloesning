module CatList
open DiffList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist


let testList4 = Append (Single 4, Single 5)

let testList5 = (Append (Append (Single 3, Single 5), Single 7))


let nil = Empty

let single (elm:'a) : 'a catlist = Single elm  

let append (xs : 'a catlist) (ys : 'a catlist) : 'a catlist = Append (xs, ys)

let cons (elm : 'a) (xs : 'a catlist) : 'a catlist = append (single elm) xs

let snoc (xs : 'a catlist) (elm : 'a) : 'a catlist = append xs (single elm)

let rec sum' (xs : int catlist) : int =
    match xs with
    | Empty -> 0
    | Single a -> a
    | Append (ys , zs) -> sum' ys + sum' zs

let fold (cf:('a -> 'a -> 'a),(e:'a)) (f:('b->'a)) (xs:'b catlist) : 'a =
    let rec g xs =
        match xs with
            Empty -> e
            | Single x -> f x
            | Append (ys, zs) -> cf (g ys) (g zs)
    g xs

let length xs = fold ((+), 0) (fun _ -> 1) xs 

let fromCatList (xs : 'a catlist) : 'a list =
    DiffList.fromDiffList (fold (DiffList.append, DiffList.nil) DiffList.single xs)

let toCatList (xs : 'a list) : 'a catlist =
    List.foldBack cons xs nil

let item (i:int) (xs : 'a catlist) : 'a =
    let rec f i (xs : 'a catlist) = 
        match xs with
        | Single x when i = 0 -> x
        | Append (s1,s2) ->
            if i < (length (s1)) then f i (s1)
            else f (i-(length (s1))) (s2)
        |_ -> failwith "tom liste"
    f i xs

let insert (i:int) (elm:'a) (xs:'a catlist) : 'a catlist =
    let rec u i xs = 
        if i=0 then (cons elm xs)
        elif i = length xs then snoc xs elm
        else
            match xs with
            | Append (s1, s2) ->
                if i < (length (s1)) then
                    Append (u i (s1), (s2))
                else
                    Append (s1, u (i-(length s1)) s2)
            | _ -> failwith "feejl"
    u i xs

let delete (i:int) (xs:'a catlist) : 'a catlist =
    let rec u i xs = 
        match xs with
        Single elm when i = 0 -> nil
        | Append (s1, s2) ->
                if i < (length (s1)) then
                    Append (u i (s1), (s2))
                else
                    Append (s1, u (i-(length s1)) s2)
        | _ -> failwith "feejl"
    u i xs

printfn "sum test= %A" (sum' testList4) 

printfn "lenght test= %A" (length testList4)

printfn "fromCatListTest= %A" (fromCatList testList4)

printfn "toCatList= %A" (toCatList [3; 4])

printfn "Item test= %A" (item 1 testList4)

printfn "Insert test= %A" (insert 1 99 testList4)

printfn "Delete test= %A" (delete 1 testList4)



