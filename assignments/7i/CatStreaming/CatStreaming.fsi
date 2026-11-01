module CatStreaming

open System.IO

/// <summary>tjekker for korrekt input</summary>
/// <param name="string[]">en liste med forskellige filer</param>
/// <returns>en ny fil</returns>
val catWithBufferSize: int -> string[] -> int

/// <summary>kombinerer to filer til en </summary>
/// <param name="CatWithBufferSize">en funktion</param>
/// <returns>en ny fil</returns>
val cat: (string[] -> int)


/// <summary>læser mængden af bytes brugeren ønsker </summary>
/// <param name="int">mængde af bytes/param>
/// <param name="byte">buffer</param>
/// <param name="FileStream">inputfilen</param>
/// <returns>de bytes der er blevet læst</returns>
val readBytes: int -> byte[] -> FileStream -> int


/// <summary>skriver mængden af bytes brugeren ønsker </summary>
/// <param name="int">mængde af bytes</param>
/// <param name="byte">buffer</param>
/// <param name="FileStream">inputfil</param>
/// <returns>A unit</returns>
val writeBytes: int -> byte[] -> FileStream -> unit


/// <summary>læser én fil, og skriver til den anden </summary>
/// <param name="int">mængde af bytes</param>
/// <param name="byte">buffer</param>
/// <param name="FileStream">inputfil</param>
/// <param name="FileStream">inputfil</param>
/// <returns>A unit</returns>
val readAndWriteBytes: int -> byte[] -> FileStream -> FileStream -> unit


/// <summary>Åbner en fil hvis den eksisterer</summary>
/// <param name="string">navnet på en bestemt fil</param>
/// <returns>en åben fil til streaming</returns>
val openFileRead: string -> FileStream


/// <summary>Åbner en fil hvis den eksisterer</summary>
/// <param name="string list">navnet på en liste af specifikke filer</param>
/// <returns>en åben fil</returns>
val openFilesRead: string list -> FileStream option list


/// <summary>åbner en fil og skriver i den.</summary>
/// <param name="string">navnet på en bestemt fil</param>
/// <returns>en åben fil</returns>
val openFileWrite: string -> FileStream option
