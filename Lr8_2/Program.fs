open System 

type Something<'a> =
    Just of 'a
    | No

let functor f p =
    match p with
    Just a -> Just (f a)
    | No -> No

let testfunc a =
    if ((functor (fun x -> x) a) = a 
    && (functor (fun x -> x*3) (functor (fun x -> x*2) a)) = (functor ((fun x -> x*2) >> (fun x -> x*3)) a))
        then "Функтор удовлетворяет законам"
        else "Функтор не удовлетворяет законам"

let take a =
    match a with
    Just (f:'a) -> f

let returnApply a =
    Just a

let applyFunctor p1 p2 =
    match p1, p2 with
    Just f, Just a -> Just (f a)
    | _ -> No


let applyFunctorTest a b c d=
    if ( take (applyFunctor a b) = (take a) (take b)
    && (applyFunctor (returnApply c) (returnApply d)) = returnApply (c d)
    )
        then "Аппликативный функтор удовлетворяет законам"
        else "Аппликативный функтор не удовлетворяет законам" 

let monada (f:'b->Something<'b>) (a:Something<'b>) =
    match a with
    Just r ->
        (f r)
    | _ -> No

[<EntryPoint>]
let main argv =
    let s = Just(5)
    Console.WriteLine(testfunc s)
    let fs = Just(fun x -> x+3)
    let f = fun x -> x*2
    let n = 10
    Console.WriteLine(applyFunctorTest fs s f n)

    Console.WriteLine(monada (fun x -> Just(x+3)) s)
    0