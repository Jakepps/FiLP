open System

type PTS(n:string, s:string, c: char, y: int, e: float, et: string, m: int, cou: string)=
    let mutable number = n
    let mutable series = s
    let mutable category = c
    let mutable year=y
    let mutable enginePower = e
    let mutable engineType=et
    let mutable mass = m
    let mutable country=cou
    member this.Number
        with get() = number
        and set(value) = number <- value
    member this.Mass
        with get() = mass
        and set(value) = mass <- value
    member this.Category
        with get() = category
        and set(value) = category <- value
    member this.yeat
        with get() = year 
        and set(value)= year <-value
    member this.EnginePower
        with get() = enginePower
        and set(value) = enginePower <- value
    member this.Country
        with get() = country
        and set(value) = country <- value
    override this.ToString() = "Серия и номер:" + series + " "+ number + ", категория:"+ Convert.ToString(category)+ ", год производства:"+Convert.ToString(year) + ", мощность двигателя:"+ Convert.ToString(enginePower)+", тип двигателя:"+Convert.ToString(engineType)+ ", масса:"+ Convert.ToString(mass)+", страна проивзодитель:"+Convert.ToString(country);
    member this.Print() = Console.WriteLine(this.ToString())

[<EntryPoint>]
    let main argv =
    let p=PTS("3234","1110",'B',2011,2000,"Бензиновый",500,"Россия");
    p.Print()
    0 