/*
	自訂迭代器:實作 IEnumerable 和 IEnumerator
	
	IEnumerable 包含單一方法，GetEnumerator，它會傳回 IEnumerator。
	IEnumerator 藉由公開 Current 屬性和 MoveNext 和 Reset 方法來逐一查看集合。
*/

void Main()
{
	List<Person> personList = new List<Person>();
	personList.Add(new Person("John", "Smith"));
	personList.Add(new Person("Jim", "Johnson"));
	personList.Add(new Person("Sue", "Rabon"));
	
	People peopleList = new People(personList);
	
	//1. 使用foreach
	Console.WriteLine("==Foreach範例===");
	foreach (Person p in peopleList)
		Console.WriteLine(p.firstName + " " + p.lastName);

	//2. 使用IEnumerator
	Console.WriteLine("==IEnumerator範例===");
	IEnumerator eumerator = peopleList.GetEnumerator();
	while (eumerator.MoveNext()) {
		Person person = eumerator.Current as Person ; 
		
		Console.WriteLine(person.firstName + " " + person.lastName);
	}
}

public class Person
{
	public string firstName;
	public string lastName;
	
	public Person(string fName, string lName)
	{
		this.firstName = fName;
		this.lastName = lName;
	}	
}

public class People : IEnumerable
{
	private List<Person> _people ;
	 
	public People(List<Person> personList)
	{
		this._people = personList;
	}

	//需要實作 GetEnumerator()
	public IEnumerator GetEnumerator()
	{
		return new PeopleEnum(_people);
	}
}

public class PeopleEnum : IEnumerator
{
	private int index =-1 ; 
	private Person[] _persons ; 
	
	public PeopleEnum(List<Person> people)
	{
		if (people == null) 
		{
			throw new ArgumentNullException("物件為Null");
		}
		
		_persons = people.ToArray();
	}

	public object Current 
	{ 
		get {
			return _persons[index] ;
		} 
	
	}

	public bool MoveNext()
	{
		index++;
		return (index < _persons.Length);
	}
		
	public void Reset()
	{
		this.index = 0 ;
	}
}
