open System

let CloseToX (list: 'a list) x = 
    let rec CloseToX (list: 'a list) x minDifference elem = 
        match list with
        []-> elem
        |head :: tail-> if abs(head - x) < minDifference then CloseToX tail x (abs(head - x)) head 
                        else CloseToX tail x minDifference elem
    CloseToX list x list.Head list.Head

let rec ReadList2 n = 
    
    if n=0 then []
    else
    let Head = Convert.ToDouble(System.Console.ReadLine())
    let Tail = ReadList2 (n-1)
    Head::Tail

let ReadData2 = 
    Console.WriteLine("Ввидите размерность списка:")
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Ввидите список:")
    ReadList2 n

[<EntryPoint>]
let main argv =
    let list = ReadData2
    Console.WriteLine(CloseToX list 5.0)  
    0