open System

let sortByCount list = List.sortBy(fun x -> -(List.filter(fun v -> x=v) list).Length) list

[<EntryPoint>]
let main argv =
   let l = Program.readData
   sortByCount l |> Program.writeList
   
   0