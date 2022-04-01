open System


let k list = List.fold (fun acc x ->acc+1) 0 list

[<EntryPoint>]
let main argv =
    let list = Program.readData
    let new_l = List.filter (fun x -> x > 1 && x < 10) list
    let ll= k new_l
    printf "%A" ll
    0