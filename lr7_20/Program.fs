open System

let writeArray arr = 
    let rec realWriteArray (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            let nextind = ind+1
            System.Console.WriteLine( arr.[ind] )
            realWriteArray arr nextind
    realWriteArray arr 0

let ascii char = int char - int '0'

let stringFold (func: 'state -> char -> 'state) (init: 'state) (value: string) =
    let rec _stringFold (index: int) (state: 'state) =
        match index with
        | final when final = value.Length -> state
        | _ -> 
            let newState = func state (value.Chars index)
            let newIndex = index + 1
            _stringFold newIndex newState
    _stringFold 0 init

let asciiWeight string = (stringFold (fun sum v -> sum + float (ascii v)) 0.0 string) / (float string.Length)

let getMaxWeight (string: string) = 
    stringFold (fun state va ->
        if ascii (fst state) + (ascii (snd state)) + (ascii (fst (snd state))) then state else state
    ) (string.Chars 0; 0) string
//В порядке увеличения среднего веса ASCII-кода символа строки
let metod1 arrStr =
    let rec foundAvgOfKode (str:string) ind (acc:int)=
        if (ind = str.Length) then Convert.ToDouble(acc)/Convert.ToDouble(str.Length)
        else
            let nacc = acc + Convert.ToInt32(str.[ind])
            foundAvgOfKode str (ind+1) nacc
    Array.sortBy 
        (fun (str:string) -> 
            foundAvgOfKode str 0 0) 
        arrStr







let multimetod n str =
    match n with
    |1 -> writeArray (metod1 str)
 //   |2-> writeArray (metod2 str)
    |_->printfn "%A" ("cringe")

[<EntryPoint>]
let main argv =
    Console.WriteLine( "Введите количество строк: " )
    let num = System.Convert.ToInt32(Console.ReadLine())
    Console.WriteLine( "Введите строки: " )
    let arrOfStr = [| for i in 1..num -> Convert.ToString(System.Console.ReadLine()) |]
    Console.WriteLine( "Введите номер задачи: " )
    let n = System.Convert.ToInt32(Console.ReadLine())
    multimetod n arrOfStr

    0