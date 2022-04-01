open System

//сколько x в list
let Meeting list x = 
    let rec Meeting2 list x count = 
        match list with 
        []->count
        |head :: tail -> if head = x then Meeting2 tail x (count+1)
                         else Meeting2 tail x count
    Meeting2 list x 0    

//самый часто встречающийся элемент 
let MaxMeetingElem list = 
    let rec MaxMeetingElem1 list maxElem maxCount = 
        match list with 
        []-> maxElem
        |head :: tail -> if Meeting list head > maxCount then 
                            MaxMeetingElem1 tail head (Meeting list head)
                         else MaxMeetingElem1 tail maxElem maxCount
    MaxMeetingElem1 list list.Head (Meeting list list.Head)
    
//индексы самого часто встречающегося элемента массива
let MaxMeetingElemIndexes list = 
    let rec MaxMeetingElemIndexes1 list maxElem currentIndex resultList = 
        match list with
        [] -> resultList
        |head :: tail -> if head = maxElem then
                            MaxMeetingElemIndexes1 tail maxElem (currentIndex+1)(List.append resultList [currentIndex]) 
                         else 
                            MaxMeetingElemIndexes1 tail maxElem (currentIndex+1) resultList
    MaxMeetingElemIndexes1 list (MaxMeetingElem list) 0 []

[<EntryPoint>]
let main argv =

    let list = Program.readData
    //Console.WriteLine(Meeting list 6)
    //Console.WriteLine(MaxMeetingElem list)
    Program.writeList(MaxMeetingElemIndexes list)

    0