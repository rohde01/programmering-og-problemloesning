/// OPG 2g0a
/// <summary> Plusser en vektor med en anden vektor </summary>
/// <param> "vec1" er af typen "vec" </param>
/// <param> "vec2" er af typen "vec" </param> 

/// <returns> retunere en vektor "vec3" af typen vec </returns>
type vec = float * float

let vec1 = vec (1.0, 2.0)
let vec2 = vec (3.0, 4.0)

let add (vec1: vec) (vec2: vec) : vec =
    vec(fst vec1 + fst vec2, snd vec1 + snd vec2)

let vec3 = add vec1 vec2
printfn "%A" vec3

/// OPG 2g0b
/// <summary> Ganger en vektor med en konstant </summary>
/// <param> "vec4" er af typen "vec", "c" er af typen float </param> 
/// <returns> retunere en vektor "vec5" af typen vec </returns>
let vec4 = vec (3.0, 5.0)
let c = 6.0

let mul (vec4: vec) (c: float): vec =
    vec(fst vec4 * c, snd vec4 * c)

let vec5 = mul vec4 c
printfn "%A" vec5


/// OPG 2g0c
/// <summary> Roterer en vektor med vinklen a </summary>
/// <param vec6> "vec6" er af typen "vec", 
/// <param a> er en vinkel af typen float </param> 
/// <returns> retunere en vektor "vec7" af typen vec </returns>
let vec6 = vec (4.0, 7.0)

let rot (vec6: vec) (a: float) : vec =
    let x = fst vec6
    let y = snd vec6

    vec(x*cos a - y*sin a, x*sin a + y*cos a)

let vec7 = rot vec6 1.0
printfn "%A" vec7

