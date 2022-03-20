open System

//произведение цифр
//Рекурсия вверх
let rec MultUp n = 
    if n=0 then 1
    else (n%10)*MultUp (n/10)

//Хвостовая
let MultDown n =
    let rec MultDown2 n res = 
        if n=0 then res
        else 
            let NextRes= res*(n%10)
            let Nextn = n/10
            MultDown2 Nextn NextRes
    MultDown2 n 1

//Максимальная цифра
//Рекурсия вверх
let rec MaxCifrUp n = 
    if n <10 then n 
    else 
        if MaxCifrUp(n/10)>n%10 then MaxCifrUp(n/10)
        else n%10

//Хвостовая
let MaxCifrDown n =
    let rec MaxCifr n res = 
        match n with
        |0->res
        |_-> if n%10>res then (MaxCifr (n/10) (n%10))
             else MaxCifr (n/10) res
    MaxCifr n 0

//Минимальная цифра
//Рекурсия вверх
let rec MinCifrUp n = 
    if n <10 then n 
    else 
        if MinCifrUp(n/10)<n%10 then MinCifrUp(n/10)
        else n%10

//Хвостовая
let MinCifrDown n =
    let rec MinCifr n res = 
        match n with
        |0->res
        |_->
            if n%10<res then (MinCifr (n/10) (n%10))
            else MinCifr (n/10) res
    MinCifr n 10

[<EntryPoint>]
let main argv =
    Console.WriteLine( "Ввидите число:")
    let n=Convert.ToInt32(Console.ReadLine())
    Console.WriteLine( "Произведение рекурсией вверх:")
    Console.WriteLine( MultUp n)
    Console.WriteLine( "Произведение рекурсией вниз:")
    Console.WriteLine( MultDown n)
    Console.WriteLine( "Максимальная цифра рекурсией вверх:")
    Console.WriteLine( MaxCifrUp n)
    Console.WriteLine( "Максимальная цифра рекурсией вниз:")
    Console.WriteLine( MaxCifrDown n)
    Console.WriteLine( "Минимальная цифра рекурсией вверх:")
    Console.WriteLine( MinCifrUp n)
    Console.WriteLine( "Минимальная цифра рекурсией вниз:")
    Console.WriteLine( MinCifrDown n)
    0 