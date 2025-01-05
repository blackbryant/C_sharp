/*
	
	Enumerable:迭代器
	 C# LINQ 中一個非常重要且經常使用的方法，其設計體現了簡潔性、
	 靈活性和強大功能的結合，被認為是 .NET 框架中設計得非常優雅的一部分。
	
	Where 的設計核心
		(1)函式式設計：
			Where 是一個擴充方法,用於篩選集合中符合條件的元素
			它接受一個 Func<TSource, bool> 參數，代表篩選的條件
			委派的設計方式，允許我們靈活地提供任何篩選邏輯
		
		(2)延遲執行： 
			Where 返回的是一個延遲執行的迭代器，這意味著篩選邏輯僅在實際迭代時執行
			延遲執行能提升性能，避免不必要的計算
			
		(3)泛型設計:
			Where 是泛型方法，適用於任何類型的集合，實現了極大的通用性
			
		(4)鏈式操作:
			Where 的返回值是 IEnumerable<T>，這使得它可以與其他 LINQ 方法（如 Select、OrderBy 等）進行組合
		
	
	Where 的內部實現簡化版本：
	
	public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
	    if (source == null) throw new ArgumentNullException(nameof(source));
	    if (predicate == null) throw new ArgumentNullException(nameof(predicate));

	    foreach (TSource element in source)
	    {
	        if (predicate(element))   //若 predicate 返回 true，則透過 yield return 將元素返回。
	        {
	            yield return element;
	        }
	    }
	}
	
*/
void Main()
{
	//1.範例
	int[] numbers = { 1, 2, 3, 4, 5, 6 };
	var oddNumber = numbers.Where(n => n % 2 == 1);
	foreach (int n in oddNumber) 
	{
		Console.Write(n+",");  // Output: 1,3,5
	}
	Console.WriteLine();

	//2. 延遲執行
	var numbers2 = Enumerable.Range(1, 10);
	var query = numbers2.Where(n =>
    {
	  Console.WriteLine($"Processing number: {n}");
	  return n % 2 == 1;
	});
	
	//實際進行迴圈時，才會處理
	foreach (var number in query)
	{
		Console.WriteLine($"Even number: {number}");  
		//Output:
		//Even number: 1
		//Even number: 3
		//Even number: 5
	}
	
	//3. 與其他 LINQ 方法結合
	var numbers3 = Enumerable.Range(1,10)
				   .Where(n => n%2 ==1)
				   .Select(n => n*n);
				   ;

	foreach (var number in numbers3)
	{
		Console.Write($"{number},"); //Output:1,9,25,49,81,
		
	}


}





