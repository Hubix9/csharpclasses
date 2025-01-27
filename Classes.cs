using System.Dynamic;
using Interfaces;

namespace Classes;


public class ClassPoint : IPrinter {
	public int X {get; set;}
	public int Y {get; set;}

	public ClassPoint(int x, int y) {
		X = x;
		Y = y;
	}

	public void Print() {
		Console.WriteLine($"X: {X}, Y: {Y}");
	}
}

public class Car : IPrinter
	{
	public string Brand {get; set;}
	public string Model {get; set;}
	public int Year {get; set;}
	public string Color {get; set;}

	public Car(string brand, string model, int year, string color) {
		Brand = brand;
		Model = model;
		Year = year;
		Color = color;
		Console.WriteLine($"Car created with parameters: {Brand}, {Model}, {Year}, {Color}");
	}

	public virtual void Print() {
		Console.WriteLine($"Car information, Brand: {Brand}, Model: {Model}, Year: {Year}, Color: {Color}");
	}
}


public class Trabant : Car {
	public Trabant(string model, int year, string color) : base("Trabant", model, year, color) {
		Console.WriteLine($"Trabant created with parameters: {Model}, {Year}, {Color}");
	}
}

public class Ferrari : Car {
	public bool Turbo {get; set;}
	public bool Abs {get; set;}

	public Ferrari(string model, int year, bool turbo, bool abs) : base("Ferrari", model, year, "Red") {
		Turbo = turbo;
		Abs = abs;
		Console.WriteLine($"Ferrari created with parameters: {Model}, {Year}, {Color}, {Turbo}, {Abs}");
	}

	public override void Print() {
		Console.WriteLine($"Ferrari information, Brand: {Brand}, Model: {Model}, Year: {Year}, Color: {Color}, Turbo: {Turbo}, Abs: {Abs}");
	}	
	~Ferrari() {
		Console.WriteLine("Ferrari destructor called");
	}	
}

public class ElectricCar : Car, IElectricCar {
	public int BatteryCapacity {get; set;}	

	public ElectricCar(string brand, string model, int year, string color, int batteryCapacity) : base(brand, model, year, color) {
		BatteryCapacity = batteryCapacity;
		Console.WriteLine($"ElectricCar created with parameters: {Brand}, {Model}, {Year}, {Color}, {BatteryCapacity}");
	}	

	public float GetDistance() {
		return BatteryCapacity * 2.5f;
	}

}

public class ElectricTrabant : ElectricCar {
	public ElectricTrabant(string model, int year, string color, int batteryCapacity) : base("Trabant", model, year, color, batteryCapacity) {
		Console.WriteLine($"ElectricTrabant created with parameters: {Model}, {Year}, {Color}, {BatteryCapacity}");
	}
}