open System

let CountOnAB list a b = 
    let rec CountOnAB1 list a b count = 
        match list with 
        |[]-> count
        |head::tail -> if head >= a && head <= b then CountOnAB1 tail a b count+1
                               else CountOnAB1 tail a b count
    CountOnAB1 list a b 0

[<EntryPoint>]
let main argv =
    let list = Program.readData
    Console.WriteLine(CountOnAB list 1 10)

    0