#r "nuget:DIKU.Canvas, 1.0.1"

// Definitioner for canvas-illustrationen.
open Canvas

// Definer vektortypen, der tager to floats som argumenter.  
type vec = float * float 
 
// Funktionen toInt tager et argument af vektortypen med floats og omdanner de to koordinatsæt til ints. 
let toInt (v : vec) : int * int =
    (int(fst v), int(snd v))

// Funktionen add tager to vektorer som argument og returnerer en additionsvektor (x1 + x2, y1 + y2)
let add (vec1: vec) (vec2: vec) : vec =
    vec(fst vec1 + fst vec2, snd vec1 + snd vec2)

let additionVector1 = (350.0, 350.0)
let additionVector2 = (350.0, 0.0)

let setVector (can: canvas) (col: color) (p: vec) (v: vec) : unit =
    setLine can col (toInt p) (toInt (add p v))

// Lægger en horisontal vektor lavet ved at addere to vektorer: 
// setVector C blue (additionVector1) (additionVector2)
// do show C "Test" 

/// <summary> Tager en vektor og roterer vinklen ved hjælp af sinus og cosinus. 
/// <param v> 
/// <returns>    
let rot (v: vec) (a: float) : vec =
    let x = fst v
    let y = snd v
    (x*cos a - y*sin a, x*sin a + y*cos a)

/// <summary> Kalder funktionen add på et vektorsæt for at skabe et nyt koordinatsæt og kalder funktionen rot
/// for at roterer vektoren med en given vinkel. Funktionerne kaldes 36 gange.
/// <param name="w"> Bredden på canvas.
/// <param name="h"> Højden på canvas.
/// <returns> 36 vektorer med en cirkels vinkler delt lige imellem sig og tegner dem på Canvas. 
let draw (w: int) (h: int) =
    let c = create w h 
    let v1 = vec(350.0, 350.0)
    let v2 = vec(350.0, 0.0)
    let degree = ((2.0 * System.Math.PI)/36.0)
    let rotvec = rot v1 degree           
    let vEnd = add v1 v2 
    for i = 0 to 35 do 
        setVector c red v1 (rot(vEnd)((float i)/(degree)))
    c    

show (draw 700 700) "p to p+v" 