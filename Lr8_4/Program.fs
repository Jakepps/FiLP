open System

let printerAgent = MailboxProcessor.Start(fun inbox->
    let rec messageLoop() = async{
        let! msg = inbox.Receive()
        
        match msg with 
        |"Вилка" -> printfn "%A" ("Я не видел одноглазых програмистов")
        |"Ложка" -> printfn "%A" ("так,это уже не канон")
        |other ->printf "%A" ("Мы ограничены цензурой")
        return! messageLoop()
        }
    messageLoop()

    )
[<EntryPoint>]
let main argv =
    let a1=printerAgent.Post("Вилка")
    let a2=printerAgent.Post("Ложка")
    let a3=printerAgent.Post("F#")
    Console.ReadKey()
    0 // return an integer exit code