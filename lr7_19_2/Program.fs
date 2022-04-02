open System
let Orderlines str =
    let justLower = String.filter (fun x -> Char.IsLower x) str
    let rec isOrder (str: string) ind =
        if (ind = str.Length-1) then true
        else
            if (str.[ind] <= str.[ind+1]) then isOrder str (ind+1)
            else false
    isOrder justLower 0

let provA str=
    let prov2 = String.filter(fun x-> x='A') str
    prov2.Length



let choose n str =
    match n with
    | 1 -> printfn "%b" (Orderlines str)
    | 2 -> printfn "%i" (provA str)
 //   | 3-> printfn "%s" (namefile str)
    |_-> printfn "%A" ("Cringe")

[<EntryPoint>]
let main argv =
     printfn "%A" "Введите строку: " 
     let str = Convert.ToString(Console.ReadLine())
     printfn "%A" "Введите номер задачи: " 
     let n = Convert.ToInt32(Console.ReadLine())
     choose n str   
    
     0
