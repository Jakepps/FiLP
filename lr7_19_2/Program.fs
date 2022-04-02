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

let namefile str =
    let rec takeBackWhile (str: string) separator ind =
        if (ind = -1) then str
        else
            if (str.[ind] = separator) then str.[(ind+1)..]
            else takeBackWhile str separator (ind-1)
    let rec takeWhile (str: string) separator ind =
        if (ind = str.Length) then str
        else
            if (str.[ind] = separator) then str.[..(ind-1)]
            else takeWhile str separator (ind+1)
    let justFile = takeBackWhile str '\\' (str.Length-1)
    takeWhile justFile '.' 0

let choose n str =
    match n with
    | 1 -> printfn "%b" (Orderlines str)
    | 2 -> printfn "%i" (provA str)
    | 3-> printfn "%s" (namefile str)
    |_-> printfn "%A" ("Cringe")

[<EntryPoint>]
let main argv =
     printfn "%A" "Введите строку: " 
     let str = Convert.ToString(Console.ReadLine())
     printfn "%A" "Введите номер задачи: " 
     let n = Convert.ToInt32(Console.ReadLine())
     choose n str   
    
     0
