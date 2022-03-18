open System
 
 [<EntryPoint>]
 let main argv =
     let vopr (lang:string)=
         match lang.Trim() with
         |"F#"|"Prolog" -> "Подлиза"
         |"C++" -> "попущ"
         |"Python"->"гиренко в школе"
         |"C#" -> "боже выйди"
         |"Pascal" -> "когда на утренник ?"
         |_ ->"ясно биофак" 

     //Суперпозиция
     Console.WriteLine("Какой твой люимый язык программирования?")
     (Console.ReadLine >> vopr >> Console.WriteLine)()

    //Каррирование
     Console.WriteLine("Какой твой люимый язык программирования?")
     let result vopr func out = out(func(vopr()))
     result Console.ReadLine vopr Console.WriteLine

     0 