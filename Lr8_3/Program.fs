open FParsec
open System
//open Functions

type Expr =
| Value of float
| Plus of Expr * Expr
| Minus of Expr * Expr

//пропуск пробелов
let pstring_ws s = spaces >>. pstring s .>> spaces //знак или скобка
let float_ws = spaces >>. pfloat .>> spaces //число

let parseExpression, implementation =
    createParserForwardedToRef<Expr, unit>()// создание парсера, что строку преобразует в алгебраический тип

let parsePlus = 
    tuple2 (parseExpression .>> pstring_ws "+") parseExpression |>> Plus// Парсит строку с +
let parseMinus = 
    tuple2 (parseExpression .>> pstring_ws "-") parseExpression |>> Minus
let parseExpr = 
    between (pstring_ws "(") (pstring_ws ")") (attempt parsePlus <|> parseMinus)// Парсит строку, что является выражение
let parseValue = 
    float_ws |>> Value // Парсит строку, что является числом

implementation := parseValue <|> parseExpr // основные элементы, с которыми работает парсер

let rec Execute expr = // считает полученный алгебраический тип
    match expr with
    | Value(a) -> a
    | Plus(a,b) | Minus(a,b) ->
        let left = 
            match a with
            | Value(v) -> v
            | Plus(_,_) | Minus(_,_) -> Execute a
        let right = 
            match b with
            | Value(v) -> v
            | Plus(_,_) | Minus(_,_) -> Execute b
        match expr with
        | Plus(_,_) -> left + right
        | Minus(_,_) -> left - right
        | _ -> 0

[<EntryPoint>]
let main argv =
    let input = Console.ReadLine()

    let result = run parseExpression input
    printfn "%A" result
    match result with
    | Success(result, _, _) ->
        let eval1 = Execute(result)
        printfn "Результат вычислений: %f" eval1
    | Failure(errorMsg, _, _) -> printfn "Failure: %s" errorMsg
    0
