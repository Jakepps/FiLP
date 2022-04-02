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