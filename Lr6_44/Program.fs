open System

let Alteration list = 
    let rec Alteration1 list t = 
        match list with 
        |[]->true
        |head :: tail -> if (abs(t%1.0) = 0.0) then 
                                                if (abs(head%1.0) <> 0.0) then Alteration1 tail head
                                                else false
                         else
                            if (abs(head%1.0) = 0.0) then Alteration1 tail head
                            else false
    Alteration1 list list.[1]       
    
let CheckList list = 
    if Alteration list then Console.WriteLine("Чередуются")
    else Console.WriteLine("Не чередуются")

[<EntryPoint>]
let main argv =
    let list = Program.ReadData2
    CheckList list
    0