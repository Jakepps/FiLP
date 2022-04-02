open System
let rec readlist n = 
    if n=0 then []
    else
    let Head = Convert.ToInt32(System.Console.ReadLine())
    let Tail = readlist (n-1)
    Head::Tail

let readData = 
    printfn "%A" "Введите размерность списка:"
    let n=Convert.ToInt32(Console.ReadLine())
    printfn "%A""Введите список:"
    readlist n 

let readData2 = 
    printfn "%A" "Введите размерность списка:"
    let n=Convert.ToInt32(Console.ReadLine())
    printfn "%A""Введите список:"
    readlist n 

let rec writeList list = 
    match list with
    | [] ->
        0
    | (head : int)::tail -> 
        printfn "%A"head
        writeList tail


[<EntryPoint>]
let main argv =   
    let array1=readData 
    let array2=readData2
    let array0= array1
    let array1=List.filter(fun x-> (List.filter(fun y->y=x)array2).Length=0) array1
    let array2=List.filter(fun x-> (List.filter(fun y->y=x)array0).Length=0) array2
    writeList array2
    0