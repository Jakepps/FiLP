open System

//находит первый максимум и его индекс
let Fmax (list: 'a list) = 
    let rec Fmax1 (list: 'a list) maxElem maxIndex currentIndex= 
        match list with 
        []->(maxElem, maxIndex)

        |head::tail-> if head > maxElem then                       
                        Fmax1 tail head currentIndex (currentIndex+1)
                      else
                        Fmax1 tail maxElem maxIndex (currentIndex+1)
    Fmax1 list list.Head 0 0

//проверка есть ли элемент х в списке
let rec ExInlist (list: 'a list) x = 
    match list with 
    []->false
    |head::tail-> if head = x then true
                  else
                    ExInlist tail x

let MisNum list a b = 
    let rec MisNum1 list a b currentNumber result = 
        if currentNumber = b then result
        else 
            if not(ExInlist list currentNumber) then MisNum1 list a b (currentNumber+1) (result @ [currentNumber])
            else MisNum1 list a b (currentNumber+1) result
    MisNum1 list a b (a+1) []

let answer list = 
    MisNum list (fst(Program.FirstMin list)) (fst(Fmax list))


[<EntryPoint>]
let main argv =
    let list = Program.readData
    Program.writeList (answer list)
    0