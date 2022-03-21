open System 

let Del n f init=
    let rec FDel n f init newN=
        if newN=0 then init
        else 
            let NextInit=
                if n%newN=0 then f init newN
                else init
            let supernewN=newN-1
            FDel n f NextInit supernewN
    FDel n f init n

[<EntryPoint>]
let main c= 
    Console.WriteLine("Ввидите число:")
    let n = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine(Del n (fun x y -> x+y) 1)
    0