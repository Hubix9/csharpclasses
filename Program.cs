namespace Prezentacja;

using Structures;
using Classes;
using Interfaces;
using Singleton;

class Program
{
    static void Main(string[] args)
    {
        Structures();
        //Classes();
        //Interfaces();
        //Singletons();
        //ValueSemantics();
        //ReferenceSemantics();
    }

    static void Structures() {
        Console.WriteLine("Structures");
        // Inicjalizator obiektu może zostać uruchomiony bezpośrednio
        // Bez wcześniejszego utworzenia instancji struktury
        Point myPoint0 = new Point { X = 0, Y = 0 };
        myPoint0.Print();

        // Konstruktor oparty o 2 parametry
        Point myPoint1 = new Point(0, 1);
        myPoint1.Print();

        // Konstruktor oparty o 1 parametr
        Point myPoint2 = new Point(2);
        myPoint2.Print();

        // Konstruktor bez parametrów
        Point myPoint3 = new Point();
        myPoint3.Print();

        // Konstruktor oparty o 1 parametr typu string
        Point myPoint4 = new Point("4");
        myPoint4.Print();

        // Konstruktor oparty o 2 parametry typu string
        Point myPoint5 = new Point("5", "6");
        myPoint5.Print();

    }

    static void Classes() {
        Console.WriteLine("Classes");
        // Samochody

        Car myCar = new Car("Ford", "Mustang", 2000, "Black");
        myCar.Print();

        Trabant myTrabant = new Trabant("601", 1969, "White");
        myTrabant.Print();

        Ferrari myFerrari = new Ferrari(model: "F40", year: 1987, turbo: true, abs: false);
        myFerrari.Print();

    }

    static void DestructorClass() {
        Ferrari myFerrari = new Ferrari(model: "F40", year: 1987, turbo: true, abs: false);
        myFerrari.Print();
        
        // Wymuszamy usunięcie obiektu z pamięci środowiska, jednocześnie wywołując destruktor jego instancji
        myFerrari = null;
        GC.Collect();
        GC.WaitForPendingFinalizers();
        // W konsolii powinno zostać wypisane:
        // "Ferrari destructor called"
    }

    static void Interfaces() {
        Console.WriteLine("Interfaces");
        // Sprawdzamy czy możemy wykonać metodę przyjmującą interfejs jako parametr

        Point myPoint = new Point(1, 2);
        InterfaceTester.TestInterface(myPoint);

        Car myCar = new Car("Ford", "Mustang", 2000, "Black");
        InterfaceTester.TestInterface(myCar);

        ElectricTrabant electricTrabant = new ElectricTrabant("nT", 2009, "White", 100); 
        float distance = electricTrabant.GetDistance();
        Console.WriteLine($"Distance: {distance}");

    }

    static void Singletons() {
        Console.WriteLine("Singleton");

        SingletonExample singleton = SingletonExample.GetInstance();
        Console.WriteLine($"Counter: {singleton.GetCount()}");  
        for (int i = 0; i < 5; i++) {
            singleton.Increment();
        }
        Console.WriteLine($"Counter: {singleton.GetCount()}");

        SingletonExample newReference = SingletonExample.GetInstance();
        Console.WriteLine($"New reference Counter: {newReference.GetCount()}");

        newReference.Reset();
        Console.WriteLine($"New reference Counter after reset: {newReference.GetCount()}");
        Console.WriteLine($"Old reference Counter after reset: {singleton.GetCount()}");
    }

    static void ValueSemantics() {
        Console.WriteLine("Value Semantics");

        Point structPoint = new Point(20, 20);
        Console.WriteLine($"structPoint, X: {structPoint.X}, Y: {structPoint.Y}");

        Point copyOfStructPoint = structPoint;
        Console.WriteLine($"copyOfStructPoint, X: {copyOfStructPoint.X}, Y: {copyOfStructPoint.Y}");

        structPoint.X = 30;
        Console.WriteLine($"structPoint, X: {structPoint.X}, Y: {structPoint.Y}");
        Console.WriteLine($"copyOfStructPoint, X: {copyOfStructPoint.X}, Y: {copyOfStructPoint.Y}");
    }

    static void ReferenceSemantics() {
        Console.WriteLine("Reference Semantics");

        ClassPoint classPoint = new ClassPoint(20, 20);
        Console.WriteLine($"classPoint, X: {classPoint.X}, Y: {classPoint.Y}");
        
        ClassPoint copyOfClassPoint = classPoint;
        Console.WriteLine($"copyOfClassPoint, X: {copyOfClassPoint.X}, Y: {copyOfClassPoint.Y}");

        classPoint.X = 30;
        Console.WriteLine($"classPoint, X: {classPoint.X}, Y: {classPoint.Y}");
        Console.WriteLine($"copyOfClassPoint, X: {copyOfClassPoint.X}, Y: {copyOfClassPoint.Y}");

        // Czy da się przekazywać referencje do struktur?

        Point structPoint = new Point(20, 20);
        Console.WriteLine($"structPoint, X: {structPoint.X}, Y: {structPoint.Y}");

        ref Point referenceOfStructPoint = ref structPoint;
        Console.WriteLine($"referenceOfStructPoint, X: {referenceOfStructPoint.X}, Y: {referenceOfStructPoint.Y}");
        
        structPoint.X = 30;
        Console.WriteLine($"structPoint, X: {structPoint.X}, Y: {structPoint.Y}");
        Console.WriteLine($"referenceOfStructPoint, X: {referenceOfStructPoint.X}, Y: {referenceOfStructPoint.Y}");

        // Struktura może być przechowywana na stercie (Heap)? 

        object boxedPoint = structPoint;
        Console.WriteLine($"boxedPoint, X: {((Point)boxedPoint).X}, Y: {((Point)boxedPoint).Y}");

        object boxedPointReference = boxedPoint;
        Console.WriteLine($"boxedPointReference, X: {((Point)boxedPointReference).X}, Y: {((Point)boxedPointReference).Y}");

    }
}



