namespace Structures;
using Interfaces;

public struct Point : IPrinter {
	public int X {get; set;}
	public int Y {get; set;}


	// Wbudowany domyślny konstruktor
	// public Point() {}

	public Point(int x, int y) {
		X = x;
		Y = y;
	}

	public Point(int x) : this(x, x) {}

	public Point() : this(10) {}

	// Wybór konstruktora zależy od liczby i typów podanych parametrów
	public Point(string x) : this(int.Parse(x)) {}

	public Point(string x, string y) : this(int.Parse(x), int.Parse(y)) {}

	public void Print() {
		Console.WriteLine($"X: {X}, Y: {Y}");
	}

}