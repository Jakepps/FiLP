open System

[<AbstractClass>]
type GeometryFigure() =
    abstract member Area: unit -> double
    abstract member Pi: double
    default this.Pi = 3.14

type IPrint = interface
    abstract member Print: unit -> unit
    end

//прямоугольник
type Rectangle(h:double, w:double) =
    inherit GeometryFigure()
    let mutable height = h
    let mutable width = w
    member this.Heigth
        with get() = height
        and set(value) = height <- value
    member this.Width
        with get() = width
        and set(value) = width <- value
    override this.Area() = (width*height)
    override this.ToString() = "Прямоугольник со сторонами " + Convert.ToString(width) + " и " + Convert.ToString(height) + ", и с площадью равной " + Convert.ToString(this.Area())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

//квадрат
type Square(a:double, b:double) =
    inherit Rectangle(a,a)
    let mutable side = a
    new(a:double) = Square(a,a)
    override this.ToString() = "Квадрат со стороной " + Convert.ToString(a) + ", и с площадью равной " + Convert.ToString(this.Area())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

//круг
type Circle(r:double) =
    inherit GeometryFigure()
    let mutable radius = 0.0
    member this.Radius
        with get() = radius
        and set(value) = radius <- value
    override this.Area() = this.Pi*radius*radius
    override this.ToString() = "Круг с радиусом " + Convert.ToString(radius) + ", и с площадью равной " + Convert.ToString(this.Area())
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        end

type Shapes =
 | Rectangle of double * double
 | Square of double
 | Circle of double
 
let GetArea (a: Shapes) =
    match a with
    | Rectangle(a,b) -> a*b
    | Square(a) -> a*a
    | Circle(r) -> r*r*Math.PI


[<EntryPoint>]
let main argv =
    let otv = new Square(10.0)
    //Console.WriteLine(otv.Area())
    Console.WriteLine(otv.ToString())
    let otv2 = Rectangle(5.0,10.0)
    Console.WriteLine(GetArea(otv2))

    0