open System

let NOD x y =
    let rec RecNOD x y del = 
        if del = 1 then true
        else 
            if (x%del=0 && y%del=0) then false
            else RecNOD x y (del-1)
    if x>y then RecNOD x y y
    else RecNOD x y x

//Обход взаимно простых компонентов числа
let TMSCON n f init = 
    let rec SimpleNum n f init num = 
        if num = 0 then init
        else 
            let nextInit=
                if (NOD n num) = true then (f init num)
                else init
            let nextNum = num-1
            SimpleNum n f nextInit nextNum
    SimpleNum n f init (n-1)

let Eyler n = 
    TMSCON n (fun x y -> x+1) 0

[<EntryPoint>]
let main argv =
    Console.WriteLine(Eyler 36)

    0 