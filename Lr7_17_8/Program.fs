open System
//Для введенного списка построить список из элементов, для которых в
//данном списке встречаются все простые делители.
//проверим на простоту. если колдел =2 тру
let kol_del x =
    let rec kol_del1 x del kol =
        if del = 0 then kol
        else
            let new_sum = if x % del = 0 then kol + 1 else kol
            let new_del = del - 1
            kol_del1 x new_del new_sum
    kol_del1 x x 0

//умножение на число
let mult list value =
    List.map (fun x -> x * value) list

// строит список из перемножений всех элементов
let rec testMult list =
    match list with
    |[]->[]
    | a::b::[] -> [a;b;(a * b)]
    | a::t -> [a]@(testMult t)@(mult (testMult t) a)

[<EntryPoint>]
let main argv =
    let l=Program.readData
    //List.distinct-позволяет cтроить список без повторений элементов
    let prostoy_l = List.distinct(List.filter (fun x -> kol_del x = 2) l)
     
    let i = testMult prostoy_l
    Program.writeList i
    0 
