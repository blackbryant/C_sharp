/*
不可變設計（Immutable Design）:物件一旦創建後，其屬性就無法更改。這在多線程環境和函數式編程中尤為重要

定義: 狀態固定、值相等性、初始化一次

優勢:
	(1) 安全性（Thread Safety）： 不可變物件在多線程環境下無需同步，因為它們的狀態無法改變。
	(2) 可預測性（Predictability）： 一旦物件被創建，其狀態就固定。
	(3) 可重用性（Reusability）： 不可變物件可以安全地在多處使用而不影響彼此。

宣告不可變的方式:
(1) 使用 readonly 或提供只有 get 訪問器的屬性
(2) 使用 record 實現不可變設計


*/

void Main()
{
	//1.record 不可變物件
	Dtos.UserDto userDtos = new Dtos.UserDto(1,"jack") ; 
	//userDtos.Name="Mary" ; //error: init-only property
	
	//2. readonly 宣告不可變欄位
	var person = new ImmutablePerson("John", "Doe");
	//person.FirstName="Kack" ;  // error: A readonly field
	
	//3. 只有 get 訪問器
	var car = new ImmutableCar("Toyota", "Corolla");
	//person.FirstName = "Jane";  //error: A readonly field
	 
	 
}

// 1.record 不可變物件
public class Dtos
{
	public record UserDto(int Id, string Name);
	
	
}

//2. readonly 宣告不可變欄位
public class ImmutablePerson
{
	public readonly string FirstName;
	public readonly string LastName;

	// 只能在建構函數中初始化
	public ImmutablePerson(string firstName, string lastName)
	{
		FirstName = firstName;
		LastName = lastName;
	}
}

//3. 只有 get 訪問器
public class ImmutableCar
{
	public string Make { get; } // 只有 get 訪問器
	public string Model { get; } // 只有 get 訪問器

	// 使用建構函數初始化
	public ImmutableCar(string make, string model)
	{
		Make = make;
		Model = model;
	}
}

