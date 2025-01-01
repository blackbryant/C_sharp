//第一個泛型程式
//範例: 1. 泛型類別、2. 泛型方法、3. 泛型介面
//

void Main()
{
	//1. 泛型類別
	var intGeneric = new GenericClass<int>(123);
	intGeneric.Display(); // Output: Value: 123

	var stringGeneric = new GenericClass<string>("Hello");
	stringGeneric.Display(); // Output: Value: Hello
	
	//2. 泛型方法
	
	User user = new User("Jack",18);
	GenericMethod.PrintAny<User>(user);//Output: etity=>Name:Jack, Age :18
	
	//3. 泛型介面
	IGeneric<string> generList = new ListGeneric<string>();
	generList.Add("Jack") ;  //[0]
	generList.Add("Mary") ;  //[1]
	generList.Add("Hold") ;  //[2]
	generList.Add("Sailiy"); //[3]
	generList.Update(3,"Hark" );

	Console.WriteLine($"{generList.GetByIndex(3)}") ;  //Output: Hark
	generList.Delete(2);

	generList.PrintAll(); //Output: Jack,Mary,Hark,

}

//泛型應用:1. 泛型類別
//定義類別時，使用T來代表所有型態，不需要明確定義資料型態，允許處理任何型別：
public class GenericClass<T>
{
	public T Value { get; set; }

	public GenericClass(T value)
	{
		Value = value;
	}

	public  void Display()
	{
		Console.WriteLine($"Value: {Value}");
	} 
}

public class GenericMethod() 
{
	//2. 泛型方法
	//針對單一方法使用泛型型別參數
	public static void PrintAny<T>(T entity)
	{

		Console.WriteLine($"entity=> {entity.ToString()}");
	}
}

//3. 泛型介面
public interface IGeneric<T> 
{
	T GetByIndex(int index);
	void Add(T item);
	void Update(int index, T item);
	void Delete(int index);
	void PrintAll();
	
}

public class ListGeneric<T> : IGeneric<T>
{
	private List<T> _items = new List<T>();
	
	public T GetByIndex(int index)
	{
		T item ; 
		try
		{
			 item = _items[index];
		}
		catch (ArgumentOutOfRangeException ex) 
		{
			throw new Exception("超出範圍") ;
			
		}
		return item ; 
	}

	public void Add(T item)
	{
		 _items.Add(item);
	}

	public void Delete(int index)
	{
		_items.RemoveAt(index);
	}


	public void Update(int index, T item)
	{
	   _items[index] = item; 
	}

	public void PrintAll()
	{
		foreach (T item in _items) 
			Console.Write($"{item.ToString()},");
		Console.WriteLine();
	}
}



//使用者物件
public class User 
{
	public string Name { set; get; }
	public int Age { set; get; }

	public User(string Name, int Age) 
	{
		this.Name = Name;
		this.Age = Age ; 
	}

	public override string ToString()
	{
		return $"Name:{Name}, Age :{Age}"  ;
	}
}


