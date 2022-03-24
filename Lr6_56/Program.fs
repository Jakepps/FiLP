open System

let Prime x = 
    let rec Prime1 x currentDivider = 
        if currentDivider = 1 then true
        elif x%currentDivider = 0 then false
        else Prime1 x (currentDivider-1)
    Prime1 x (x-1)

//среднее арифметическое простых элементов списка
let SrPr (list: 'a list) = 
   let rec SrPr1 (list: 'a list) sum count = 
       match list with
       []-> if count = 0 then 0
            else sum/count
       |head :: tail-> if Prime head then SrPr1 tail (sum+head) (count+1)
                       else SrPr1 tail sum count
   SrPr1 list 0 0

let SrPrCon (list: 'a list) condition = 
    let rec SrPrCon1 (list: 'a list) sum count condition = 
        match list with
        []-> if count = 0 then 0
             else sum/count
        |head :: tail-> if not(Prime head) && head > condition then SrPrCon1 tail (sum+head) (count+1) condition
                        else SrPrCon1 tail sum count condition
    SrPrCon1 list 0 0 condition

[<EntryPoint>]
let main argv =
    let list = Program.readData
    Console.WriteLine(SrPrCon list (SrPr list))
    0