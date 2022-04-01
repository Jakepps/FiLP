open System
//найти среднее арифметическое модулей его элементов.
let rec readList n =
    List.init(n) (fun index->Console.ReadLine()|>Convert.ToDouble)

let readData = 
    let n=Convert.ToInt32(System.Console.ReadLine())
    readList n

let AverageAbsList list = List.average (List.map (fun (x:float)-> Math.Abs(x)) list )

[<EntryPoint>]
let main argv =
    readData|>AverageAbsList |> Console.WriteLine

    0