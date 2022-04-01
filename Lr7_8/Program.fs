open System

let rec remove i l =
    match i, l with
    | 0, x::xs -> xs
    | i, x::xs -> x::remove (i - 1) xs
    | i, [] -> failwith "index out of range"

let Min2 (list: 'a list) =     
    let minIndex1 = List.findIndex (fun x -> x = List.min list) list
    let list = remove minIndex1 list
    let minIndex2 = List.findIndex (fun x -> x = List.min list) list
    if minIndex2 >= minIndex1 then (minIndex1, (minIndex2))
    else (minIndex1, minIndex2)
    

[<EntryPoint>]
let main argv =

    let list = Program.readData
 
    Console.WriteLine(Min2 list)
    0