open System
//удаление элемента из списка с номером n
let DelElem list n = 
    let rec DelElem1 (list: 'a list) n (list1: 'a list) currentIndex = 
        if n = currentIndex then list1 @ list.Tail
        else
            let newList1 = list1 @ [list.Head]
            DelElem1 list.Tail n newList1 (currentIndex+1)
    DelElem1 list n [] 0


let rec ShiftListRight (list: 'a list) n =
    if n=0 then list
    else
        if list.Length <= 1 then list 
        else
           ShiftListRight ([list.[list.Length-1]] @ DelElem list (list.Length-1)) (n-1) // список, полученный путём list[last]+list без последнего эл-та

[<EntryPoint>]
let main argv =
    let list = Program.readData
    Program.writeList(ShiftListRight list 2)
    //1 2 3 4 5 ->4 5 1 2 3 
    0