open System


let rec readlist n = 
    if n=0 then []
    else
    let Head = Convert.ToInt32(System.Console.ReadLine())
    let Tail = readlist (n-1)
    Head::Tail

let readData = 
    Console.WriteLine("Введите размерность списка:")
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Введите список:")
    readlist n

let rec writeList list = 
    match list with
    | [] ->
        0
    | (head : int)::tail -> 
        Console.WriteLine(head)
        writeList tail
        
//Дополняем список до размерности %3
let DopList3 lint = 
    if List.length lint % 3=0 then lint
    else 
        if List.length lint % 3=1 then lint @ [1] @ [1]
        else lint @ [1]

let SumList3 f lint =
    let rec Sum3 lint f newList = 
        match lint with
        |[]-> newList
        |h::tail->
            let h2 = tail.Head
            let h3 = tail.Tail.Head
            let resSum = f h h2 h3
            let NextList = newList @ [resSum]
            Sum3 tail.Tail.Tail f NextList
    Sum3 lint f []

[<EntryPoint>]
let main argv =
    let l = readData
    DopList3 l |> SumList3 (fun x y z->x+y+z) |>writeList
    //1 2 3 4 5 ->6 10
    0