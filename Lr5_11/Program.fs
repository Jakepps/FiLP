open System

let vopr q = 
    match q with
        |"F#" | "Prolog" -> printfn "Подлиза"
        |other -> printfn "%s"("Кринж")

[<EntryPoint>]
let main argv =
    printfn "Какой твой люимый язык программирования?"
    let c = Console.ReadLine()
    vopr c
    0
