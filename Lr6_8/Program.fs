open System

let Min list = 
    let rec Min2 list min1 min2 index1 index2 currentIndex = 
        match list with 
        |[] -> (index1, index2)
        |head::tail-> if (head <= min1 && head >= min2 && currentIndex <> index1) then 
                                        Min2 tail head min2 currentIndex index2 (currentIndex+1)
                      elif (head >= min1 && head <= min2 && currentIndex <> index2) then 
                                        Min2 tail min1 head index1 currentIndex (currentIndex+1)
                      elif (head <= min1 && head <= min2)  then 
                                        if min1 <= min2 then Min2 tail min1 head index1 currentIndex (currentIndex+1)
                                        else Min2 tail head min2 currentIndex index2 (currentIndex+1)
                      else
                                        Min2 tail min1 min2 index1 index2 (currentIndex+1)
    Min2 list list.[0] list.[1] 0 1 0

[<EntryPoint>]
let main argv =
    let list = Program.readData
    Program.writeList list
    Console.WriteLine(Min list)   
    //4 5 1 2 3 ->(2,3)
    0