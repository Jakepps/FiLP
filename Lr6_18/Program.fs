open System

let FirstMin (list: 'a list) = 
    let rec FirstMin1 (list: 'a list) minElem minIndex currentIndex= 
        match list with 
        []->(minElem, minIndex)

        |head::tail-> if head < minElem then                       
                        FirstMin1 tail head currentIndex (currentIndex+1)
                      else
                        FirstMin1 tail minElem minIndex (currentIndex+1)
    FirstMin1 list list.Head 0 0

//элементы списка до N
let ElemBeN (list: 'a list) n = 
    let rec ElemBeN1 (list: 'a list) n currentIndex resultList = 
        if currentIndex = n then resultList
        else
            ElemBeN1 list.Tail n (currentIndex+1) (resultList @ [list.Head])
    ElemBeN1 list n 0 []

[<EntryPoint>]
let main argv =
    let list = Program.readData
    //Program.writeList(list)
    //Console.WriteLine(FirstMin list)

    Program.writeList (ElemBeN list (snd(FirstMin list))) //в скобках второй элемент кортежа, т.е. индекс первого минимума в списке
    0