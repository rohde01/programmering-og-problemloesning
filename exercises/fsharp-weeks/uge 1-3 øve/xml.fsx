#r "nuget:DIKU.Canvas, 1.0"
open Canvas


/// Typer ///
type vec = float * float
type pos = int * int



// Funktioner //

// <summary>
// <param>
// <returns>
let toInt v:vec : int * int =
    (int(fst(v)),int(snd(v)))

// <summary>
// <param>
// <returns>
let setVector (C:canvas) (a: color) (p: pos) (v: vec) =
    setLine C a p (toInt(v))

/// <summary> Adds a vector to another vector </summary>
/// <param> "a" and "b" are of the type "vec" </param> 
/// <returns> Returns a vector </returns> 
let add(a:vec) (b:vec) :vec =
    fst a + fst b, snd a + snd b

/// <summary> Multiplys vector by constant </summary>
/// <param> "a" is of the type "vec", "b" is of the type float </param> 
/// <returns> vector </returns> 
let mul(a:vec) (b:float) :vec = 
    fst a * b, snd a * b

/// <summary> Converts an angle in degrees to radians </summary>
/// <param> "d" is a float </param> 
/// <returns> angle in radians </returns> 
let degToRad (d:float) =
    (dSystem.Math.PI)/180.0

/// <summary> Rotates a vector by an angle in degrees </summary>
/// <param> "a" is of the type vec, and "o" is of the type float </param> 
/// <returns> Vector </returns> 
let rot(a:vec) (o:float) :vec =
    let x = fst(a)
    let y = snd(a)
    let vinkel = degToRad(o)
    int((xSystem.Math.Cos(vinkel))-ySystem.Math.Sin(vinkel)) , int(x(System.Math.Sin(vinkel))+y(System.Math.Cos(vinkel)))



/// <summary> Draws a canvas with 36 spokes </summary>
/// <param> w and h are of the type int </param> 
/// <returns> Canvas named "C" </returns> 
let draw w h =
    /// <summary> Creates canvas </summary>
    /// <returns> Canvas named "C" </returns> 
    let C = create w h
    let v: vec = (300.0,0.0)
    let p: pos = (w/2, h/2)
    (for i in [0.0..10.0..360.0] do
        let rV = (fst(rot v i)+300.0,snd(rot v i)+300.0)
        setVector C black p rV*)
    setVector C black p (0,300)
    do show C "H";;

draw 600 600