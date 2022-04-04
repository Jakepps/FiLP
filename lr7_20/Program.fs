open System

let writeArray arr = 
    let rec realWriteArray (arr : 'T [] ) (ind : int)=
        if (ind = arr.Length) then ()
        else
            let nextind = ind+1
            System.Console.WriteLine( arr.[ind] )
            realWriteArray arr nextind
    realWriteArray arr 0


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


//В порядке увеличения квадратичного отклонения между наиболь-
//шим ASCII-кодом символа строки и разницы в ASCII-кодах пар зеркально
//расположенных символов строки (относительно ее середины)
let maxASCII (str:string) =
    let rec maxASCIIInternal index (count:int) =
        match index with
        | index when index >= str.Length - 1 -> count
        |_ ->
            let newCount = if (str.[index] |> Convert.ToInt32)  > count then (str.[index] |> Convert.ToInt32) else count
            let newIndex = index + 1
            maxASCIIInternal newIndex newCount
    maxASCIIInternal 0 ('A' |> Convert.ToInt32)

let sumRazn (str:string) =
    let rec sumRazn2 index index2 count =
        match index with
        | index when index2 <= index -> count
        |_ ->
            let newCount = (str.[index] |> Convert.ToInt32) - (str.[index2] |> Convert.ToInt32) + count
            let newIndex = index + 1
            let newIndex2 = index2 - 1
            sumRazn2 newIndex  newIndex2 newCount
    sumRazn2 0 ((str.Length) - 1) 0

let metod2 list =
    List.sortBy (fun x -> (maxASCII x - sumRazn x)*(maxASCII x - sumRazn x) ) list

let multimetod n str =
    match n with
    |1 -> writeArray (metod1 str)
    |2-> writeArray (metod2 str)
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