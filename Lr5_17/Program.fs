open System

let NOD x y =
    let rec RecNOD x y del = 
        if del = 1 then true
        else 
            if (x%del=0 && y%del=0) then false
            else RecNOD x y (del-1)
    if x>y then RecNOD x y y
    else RecNOD x y x

//Обход взаимно простых компонентов числа с условием
let TMSCON n f init condition = 
    let rec SimpleNum n f init condition num = 
        if num = 0 then init
        else 
            let nextInit=
                if ((NOD n num) = true && (condition num)) then (f init num)
                else init
            let nextNum = num-1
            SimpleNum n f nextInit condition nextNum
    SimpleNum n f init condition (n-1)

//Обход делителей с условием
let DelC n f init condition = 
    let rec FDel n f init condition newN = 
        if newN=0 then init
        else 
            let NextInit=
                if (n%newN=0 && (condition newN)) then f init newN
                 else init
            let SupernewN=newN-1
            FDel n f NextInit condition SupernewN
    FDel n f init condition n   
    

[<EntryPoint>]
let main argv =
    let res1= TMSCON 36 (fun x y -> x+y) 0 (fun x -> x>3 && x<=10)
    Console.WriteLine(res1)//12

    let res2 = DelC 12 (fun x y -> x*y) 1 (fun x -> x%2=1)
    Console.WriteLine(res2) //3

    0