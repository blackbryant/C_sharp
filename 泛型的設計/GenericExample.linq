//第一個泛型程式

void Main()
{

	var intGeneric = new GenericClass<int>(123);
	intGeneric.Display(); // Output: Value: 123

	var stringGeneric = new GenericClass<string>("Hello");
	stringGeneric.Display(); // Output: Value: Hello
	
}

//使用T來代表所有型態，不需要明確定義資料型態

public class GenericClass<T>
{
	public T Value { get; set; }

	public GenericClass(T value)
	{
		Value = value;
	}

	public void Display()
	{
		Console.WriteLine($"Value: {Value}");
	}
}

