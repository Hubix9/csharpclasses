namespace Singleton;


// Uproszczony singleton pattern
public class SingletonExample {

	private static SingletonExample? instance;

	private static int Counter {get; set;}


	// Konstruktor oznaczamy jako prywatny, aby instancje klasy nie były tworzone metodami spoza niej
	private SingletonExample() {
		Counter = 0;
	}

	public static SingletonExample GetInstance() {
		if (instance == null) {
			instance = new SingletonExample();
		}
		return instance;
	}

	public void Increment() {
		Counter++;
	}

	public int GetCount() {
		return Counter;	
	}

	public void Reset() {
		Counter = 0;	
	}

}