module CatList

type 'a catlist =
    | Empty
    | Single of 'a
    | Append of 'a catlist * 'a catlist

val nil : 'a catlist 

/// <summary>konverterer et enkelt element a' til en catlist</summary>
/// <param name="elm">'a</param>
/// <returns>en catlist med ét element</returns>
val single : 'a -> 'a catlist

/// <summary>Sætter to catlists sammen</summary>
/// <param name="xs">'a catlist</param>
/// <param name="ys">'a catlist</param>
/// <returns>en ny catlist</returns>
val append : 'a catlist -> 'a catlist -> 'a catlist 

/// <summary>laver en catlist fra et element og en catlist</summary>
/// <param name="elm">'a</param>
/// <param name="xs">'a catlist</param>
/// <returns>en ny catlist</returns>
val cons : 'a -> 'a catlist -> 'a catlist 

/// <summary>laver 'a catlist fra 'a catlist og et element</summary>
/// <param name="xs">'a catlist</param>
/// <param name="elm">'a</param>
/// <returns>en ny catlist</returns>
val snoc : 'a catlist -> 'a -> 'a catlist 

/// <summary> </summary>
/// <param name="cf">liste med 3 elementer</param>
/// <param name="f">liste med 2 elementer</param>
/// <param name="xs">b' catlist</param>
/// <returns>et element 'a</returns>
val fold : (('a -> 'a -> 'a) * 'a) -> ('b -> 'a) -> 'b catlist -> 'a

/// <summary>Konverterer en catlist til en liste</summary>
/// <param name="xs">en catlist</param>
/// <returns>en liste fra en catlist</returns>
val fromCatList : 'a catlist -> 'a list

/// <summary>Konverterer en liste til en catlist</summary>
/// <param name="xs">en liste</param>
/// <returns>en catlist fra en liste</returns>
val toCatList : 'a list -> 'a catlist

/// <summary>laver et element fra et heltal og 'a catlist</summary>
/// <param name="i">heltal</param>
/// <param name="xs">'a catlist</param>
/// <returns>et element</returns>
val item : int -> 'a catlist -> 'a

/// <summary>laver en 'catlist fra et heltal, et element og 'a catlist</summary>
/// <param name="i">heltal</param>
/// <param name="elm">'a</param>
/// <param name="xs">'a catlist</param>
/// <returns>Returnerer 'a catlist fra et heltal, et element og 'a catlist</returns>
val insert : int -> 'a -> 'a catlist -> 'a catlist

/// <summary>laver 'a catlist fra et heltal og 'a catlist</summary>
/// <param name="i">heltal</param>
/// <param name="xs">'a catlist</param>
/// <returns>Returnerer 'a catlist fra et heltal og 'a catlist</returns>
val delete : int -> 'a catlist -> 'a catlist
