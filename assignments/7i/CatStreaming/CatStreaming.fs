module CatStreaming
open System.IO

let readBytes (count:int) (buffer:byte[]) (fs:FileStream) : int =
    fs.Read(buffer, 0, count)

let writeBytes (count:int) (buffer:byte[]) (fs:FileStream) : unit =
    fs.Write(buffer, 0, count)

let readAndWriteBytes (buffersize:int) (buffer:byte[]) (ifs:FileStream) (ofs:FileStream) =
    let rec inner () =
        let readBytes = readBytes buffersize buffer ifs
        match readBytes with
            | 0 -> ifs.Close(); ofs.Flush()
            | _ ->
                writeBytes readBytes buffer ofs |> inner
    inner ()

let openFileRead (filename:string) : FileStream =
    try
        File.OpenRead filename
    with
        _ -> raise (System.IO.FileNotFoundException())

let openFilesRead (filenames : string list) : FileStream option list =
    List.map (fun filename -> try openFileRead filename |> Some with _ -> None) filenames

let openFileWrite (filename:string) : FileStream option =
    try
        File.Open(filename, FileMode.Create) |> Some
    with
        _->
            sprintf "cat: Could not create or truncate file \"%s\"" filename
            |> System.Console.Error.WriteLine
            None

let countAndOutErrors (errors:int) (filename:string) (fileStream:FileStream Option) =
    match fileStream with
        | None ->
            sprintf "cat: The file \"%s\" does not exist or is not readable" filename
            |> System.Console.Error.WriteLine
            errors + 1
        |Some _ -> errors

let catWithBufferSize (buffersize:int) (filenames:string[]) : int =
    match Array.length filenames with
        | 0 -> System.Console.Error.WriteLine "Car: no output"; 255
        | 1 -> 
            match openFileWrite filenames.[0] with
                | none -> 1
                | Some ofs -> writeBytes 0 [||] ofs; 0
        | len ->
            let buffer = Array.init buffersize (fun _ -> 0uy)
            let infiles = filenames.[..len-2] |> List.ofArray
            let outfile = filenames.[len-1]
            let inputFileStreams = openFilesRead infiles
            let outputFileStream = openFileWrite outfile
            if List.exists ((=) None) inputFileStreams then
                List.fold2 countAndOutErrors 0 infiles inputFileStreams
            else
                match outputFileStream with
                | None -> 1
                | Some ofs ->
                    List.map Option.get inputFileStreams
                    |> List.iter (fun ifs -> readAndWriteBytes buffersize buffer ifs ofs)

                    ofs.Close()
                    0

let cat = catWithBufferSize 64

