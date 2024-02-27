using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;

Console.WriteLine("Lab6 C# ");
Console.WriteLine("Exercise 1");
Console.WriteLine("User interface - Show method ");

Vehicle vehicle1 = new TransportVehicle { model = "Citroen c4", speed = 260, price = 0 };
vehicle1.Show();
Console.WriteLine();

Vehicle vehicle2 = new Car { model = "BMW M5", speed = 280, price = 150000, numberOfDoors = 4 };
vehicle2.Show();
Console.WriteLine();

Vehicle vehicle3 = new Train { model = "Freight", speed = 120, price = 500000, numberOfWagons = 50 };
vehicle3.Show();
Console.WriteLine();

Vehicle vehicle4 = new Express { model = "Stralis", speed = 500, price = 2000000000, numberOfWagons = 50, passengerWagons = true };
vehicle4.Show();
Console.WriteLine("\n");

Console.WriteLine("Interface .NET(IComparable<Vehicle>)");
Vehicle vehicle11 = new TransportVehicle { model = "Nissan GTR", speed = 400, price = 50000 };
int value1 = vehicle1.CompareTo(vehicle11);
if (value1 == 0)
    Console.WriteLine("The maximum speed is the same.");
else if (value1 < 0)
    Console.WriteLine($"{vehicle11.model} faster than {vehicle1.model}");
else
    Console.WriteLine($"{vehicle11.model} slower than {vehicle1.model}");

Vehicle vehicle22 = new Car { model = "Daewoo Matiz", speed = 160, price = 3500, numberOfDoors = 4 };
int value2 = vehicle2.CompareTo(vehicle22);
if (value2 == 0)
    Console.WriteLine("The maximum speed is the same.");
else if (value2 < 0)
    Console.WriteLine($"{vehicle22.model} faster than {vehicle2.model}");
else
    Console.WriteLine($"{vehicle22.model} slower than {vehicle2.model}");

Vehicle vehicle33 = new Train { model = "Dream", speed = 120, price = 530000, numberOfWagons = 40 };
int value3 = vehicle3.CompareTo(vehicle33);
if (value3 == 0)
    Console.WriteLine("The maximum speed is the same.");
else if (value3 < 0)
    Console.WriteLine($"{vehicle33.model} faster than {vehicle3.model}");
else
    Console.WriteLine($"{vehicle33.model} slower than {vehicle3.model}");

Vehicle vehicle44 = new Express { model = "Spirit", speed = 450, price = 5000000, numberOfWagons = 60, passengerWagons = true };
int value4 = vehicle4.CompareTo(vehicle44);
if (value4 == 0)
    Console.WriteLine("The maximum speed is the same.");
else if (value4 < 0)
    Console.WriteLine($"{vehicle4.model} faster than {vehicle44.model}");
else
    Console.WriteLine($"{vehicle4.model} slower than {vehicle44.model}");

Console.WriteLine();
Console.WriteLine("Interface .NET(ICloneable<T>)");
TransportVehicle originalTransportVehicle = new TransportVehicle{model = "Volvo XC90", speed = 260, price = 200000};
TransportVehicle clonedTransportVehicle = (TransportVehicle)originalTransportVehicle.Clone();
Console.WriteLine("Original Transport Vehicle:");
originalTransportVehicle.Show();
Console.WriteLine("\nCloned Transport Vehicle:");
clonedTransportVehicle.Show();
Console.WriteLine("\n");

Car originalCar = new Car { model = "BMW M3", speed = 220, price = 80000, numberOfDoors = 4 };
Car clonedCar = (Car)originalCar.Clone();
Console.WriteLine("Original Car:");
originalCar.Show();
Console.WriteLine("\nCloned Car:");
clonedCar.Show();
Console.WriteLine("\n");

Train originalTrain = new Train { model = "Chuh-Chuh", speed = 150, price = 200000, numberOfWagons = 10 };
Train clonedTrain = (Train)originalTrain.Clone();
Console.WriteLine("Original Train:");
originalTrain.Show();
Console.WriteLine("\nCloned Train:");
clonedTrain.Show();
Console.WriteLine("\n");

Express originalExpress = new Express { model = "Boooo", speed = 600, price = 2000000000, numberOfWagons = 10, passengerWagons = true };
Express clonedExpress = (Express)originalExpress.Clone();
Console.WriteLine("Original Express:");
originalExpress.Show();
Console.WriteLine("\nCloned Express:");
clonedExpress.Show();
Console.WriteLine("\n\n");

Console.WriteLine("Exercise 2");
var figures = new List<IFigure>();

var rectangle1 = new Rectangle(5, 10);
var rectangle2 = new Rectangle(20, 15);
var circle1 = new Circle(3);
var circle2 = new Circle(9);
var triangle1 = new Triangle(3, 4, 5);
var triangle2 = new Triangle(11, 12, 13);

figures.Add(rectangle1);
figures.Add(triangle2);
figures.Add(circle1);
figures.Add(rectangle2);
figures.Add(triangle1);
figures.Add(circle2);

foreach (var figure in figures)
{
    figure.OutputInformation();
}
figures.Sort();


Console.WriteLine("\nFigures after sorting by area:");
foreach (var figure in figures)
{
    figure.OutputInformation();
}

interface Vehicle : IComparable<Vehicle>
{
    string model { get; set; }
    double speed { get; set; }
    void Show();
}
public interface ICloneable<T>
{
    T Clone();
}

class TransportVehicle : Vehicle, ICloneable
{
    public string model { get; set; }
    public double speed { get; set; }
    public double price { get; set; }
    public TransportVehicle() { model = "Nothing"; speed = 0; price = 0; }
    public void Show()
    {
        Console.Write($"Model: {model}, Speed: {speed}, Price: {price}");
    }
    public int CompareTo(Vehicle? other)
    {
        if (other is TransportVehicle)
        {
            TransportVehicle otherTransport = (TransportVehicle)other;
            return speed.CompareTo(otherTransport.speed);
        }
        else
        {
            throw new ArgumentException("Object is not a TransportVehicle");
        }
    }
    public object Clone()
    {
        return new TransportVehicle
        {
            model = this.model,
            speed = this.speed,
            price = this.price
        };
    }
}
class Car : TransportVehicle, ICloneable
{
    public int numberOfDoors { get; set; }
    
    public new void Show()
    {
        base.Show();
        Console.Write($", Number of doors: {numberOfDoors} ");
    }
    public new object Clone()
    {
        return new Car
        {
            model = this.model,
            speed = this.speed,
            price = this.price,
            numberOfDoors = this.numberOfDoors
        };
    }
}
class Train : TransportVehicle, ICloneable
{
    public int numberOfWagons { get; set; }
    
    public new void Show()
    {
        base.Show();
        Console.Write($", Number of waagons: {numberOfWagons}");
    }
    public new object Clone()
    {
        return new Train
        {
            model = this.model,
            speed = this.speed,
            price = this.price,
            numberOfWagons = this.numberOfWagons
        };
    }
}
class Express : Train, Vehicle
{
    public bool passengerWagons { get; set; }
    
    public new void Show()
    {
        base.Show();
        Console.Write($", Passenger wagons: {passengerWagons}");
    }
    public new object Clone()
    {
        return new Express
        {
            model = this.model,
            speed = this.speed,
            price = this.price,
            numberOfWagons = this.numberOfWagons, 
            passengerWagons = this.passengerWagons
        };
    }
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////
public interface IFigure : IComparable<IFigure>
{
    double CalculateArea();
    double CalculatePerimeter();
    void OutputInformation();
}


class Rectangle : IFigure
{
    public double a { get; set; }
    private double b { get; set; }
    public Rectangle(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public double CalculateArea()
    {
        return a * b;
    }
    public double CalculatePerimeter()
    {
        return 2 * (a + b);
    }
    public void OutputInformation()
    {
        Console.WriteLine($"Rectangle: a = {a}; b = {b}; S = {CalculateArea()}; P = {CalculatePerimeter()};");
    }
    public int CompareTo(IFigure? other)
    {
        double thisPerimeter = this.CalculatePerimeter();
        double otherPerimeter = other.CalculatePerimeter();
        return thisPerimeter.CompareTo(otherPerimeter);
    }
}
class Circle : IFigure
{
    private double r;
    public Circle(double r)
    {
        this.r = r;
    }
    public double CalculateArea()
    {
        return r * r * Math.PI;
    }
    public double CalculatePerimeter()
    {
        return 2 * r * Math.PI;
    }
    public void OutputInformation()
    {
        Console.WriteLine($"Circle: radius = {r}; S = {CalculateArea()}; P = {CalculatePerimeter()}");
    }
    public int CompareTo(IFigure? other)
    {
        double thisPerimeter = this.CalculatePerimeter();
        double otherPerimeter = other.CalculatePerimeter();
        return thisPerimeter.CompareTo(otherPerimeter);
    }
}
class Triangle : IFigure
{
    private double AB;
    private double BC;
    private double AC;
    public Triangle(double AB, double BC, double AC)
    {
        this.AB = AB;
        this.BC = BC;
        this.AC = AC;
    }
    public double CalculateArea()
    {
        double p = ((AB + BC + AC) / 2);
        return Math.Sqrt(p * (p - AB) * (p - BC) * (p - AC));
    }
    public double CalculatePerimeter()
    {
        return AB + BC + AC;
    }
    public void OutputInformation()
    {
        Console.WriteLine($"Triangle: AB = {AB}; BC = {BC}; AC = {AC}; S = {CalculateArea()}; P = {CalculatePerimeter()};");
    }
    public int CompareTo(IFigure? other)
    {
        double thisPerimeter = this.CalculatePerimeter();
        double otherPerimeter = other.CalculatePerimeter();
        return thisPerimeter.CompareTo(otherPerimeter);
    }
}