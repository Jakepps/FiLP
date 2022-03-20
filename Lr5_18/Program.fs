open System

//сумма цифр числа, делящихся на 3
let sumch a b = a + b%10
let div10 a = a/10
let Sum3 x = 
    let rec Sum3 x sum  = 
        if x = 0 then sum
        else
            if x%10%3 = 0 then
                let sum1 = sumch sum x
                let x1 = div10 x
                Sum3 x1 sum1
            else 
                let x1 = div10 x
                Sum3 x1 sum
    Sum3 x 0

let NOD x y =
    let rec RecNOD x y del = 
        if del = 1 then true
        else 
            if (x%del=0 && y%del=0) then false
            else RecNOD x y (del-1)
    if x>y then RecNOD x y y
    else RecNOD x y x

 //колличество простых делителей числа
 //текущий делитель
let countf a = a+1
let CountPrNum x currentDivisor = 
    let rec CountPrNum1 x currentDivisor count = 
        if x = 0 then count
        else 
            if NOD (x%10) currentDivisor = true then
                let x = div10 x
                let count = countf count
                CountPrNum1 x currentDivisor count
            else 
                let x = div10 x
                CountPrNum1 x currentDivisor count
    CountPrNum1 x currentDivisor 0

//делитель, являющийся взаимнопростым с наибольшим количеством цифр заданного числа
let minus1 a = a-1
let MaxPrNum x = 
    let rec MaxPrNum1 x currentDivisor maxCount maxDivisor = 
        if currentDivisor = 0 then maxDivisor
        else 
            if CountPrNum x currentDivisor > maxCount then
                let maxCount = CountPrNum x currentDivisor    
                let maxCount1 = maxCount
                let maxDivisor = currentDivisor
                let currentDivisor1 = minus1 currentDivisor
                MaxPrNum1 x currentDivisor maxCount maxDivisor
            else 
                let currentDivisor1 = minus1 currentDivisor
                MaxPrNum1 x currentDivisor1 maxCount maxDivisor
    MaxPrNum1 x x 0 0


[<EntryPoint>]
let main argv =
    Console.WriteLine(Sum3 139)
    Console.WriteLine(CountPrNum 12345 5) //4
    Console.WriteLine(MaxPrNum 125) //123
    0