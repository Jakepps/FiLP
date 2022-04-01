open System

//количество элементов на  отрезке а б 
let CountElemOnAB list a b = 
    let rec CountElemOnAB1 list a b resultList count= 
        match list with
        []-> resultList
        |head :: tail -> if head >= a && head <= b then 
                                                    CountElemOnAB1 tail a b (List.append resultList [head]) (count+1)
                         else CountElemOnAB1 tail a b resultList count 
    CountElemOnAB1 list a b [] 0   
    

[<EntryPoint>]
let main argv =
    
    let list=Program.readData
    let a=CountElemOnAB list 1 10
    Console.WriteLine a

    0