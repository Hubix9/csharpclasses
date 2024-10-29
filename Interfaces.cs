namespace Interfaces;


public interface IPrinter {
	void Print();
}

public class InterfaceTester {
	public static void TestInterface(IPrinter printable) {
		printable.Print();
	}
}


public interface IElectricCar {
	public float GetDistance();
}