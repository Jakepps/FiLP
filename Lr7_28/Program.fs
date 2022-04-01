open System

[<EntryPoint>]
let main argv =
    let list = Program.readData
    let new_l = List.filter (fun x -> x < List.max list && x > List.min list) list
    let ll = List.max new_l
    Console.WriteLine ll

    0 