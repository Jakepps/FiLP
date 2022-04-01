open System

let trimListByLastMin list =
    List.init (List.findIndex (fun x -> x = List.min list) list) (fun index -> List.item index list)

[<EntryPoint>]
let main argv =
    let list = Program.readData
    Program.writeList (trimListByLastMin list)
    0