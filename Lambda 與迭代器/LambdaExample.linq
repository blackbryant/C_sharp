/* Lambda 
1. Lambda 表達式是匿名方法的一種簡化表示方式，主要用於定義內聯的函式或委派，並且廣泛應用於 LINQ、事件處理和回呼函式。	

2. 迭代器原理與實作
   允許用戶逐步遍歷集合或序列中的每一個元素，而無需完全加載集合。它通過 yield return 和 yield break 關鍵字實現延遲執行。
   迭代器使用 yield 提供延遲執行特性，適合處理大數據集。

3.實務考題範例:
	(1) 給定一個整數陣列，請使用 Lambda 表達式找出所有大於 5 的偶數，並將它們的平方加 1 後輸出。
	(2) 實作一個方法，接收一個函式作為參數，並對一個數字列表應用該函式。
	(3) 使用 LINQ to SQL 查詢資料庫，找出所有訂單金額大於 1000 元且訂單日期在今年的訂單。

*/

void Main()
{
	//1. Lambda
	// C# 2.0: 使用匿名方法
	Func<int, int> squareOld = delegate (int x) { return x * x; };
	Console.WriteLine($"Square using anonymous method: {squareOld(5)}");

	List<int> numbers2 = new List<int> { 1, 2, 3, 4, 5 };
	List<int> squaredNumbers = numbers2.ConvertAll(delegate (int x) { return x * x; });

	Console.WriteLine("Using Anonymous Method (C# 2.0):");
	squaredNumbers.ForEach(Console.WriteLine);

	// C# 3.0 Lambda 表達式: 使用 => 簡化匿名方法，應用於 LINQ 和回呼函數
	Func<int, int> square = x => x * x;
	Console.WriteLine($"Square using lambda: {square(5)}");

	// C# 6.0: 表達式函數
	Func<int, int> cube = x => x * x * x;
	Console.WriteLine($"Cube using expression function: {cube(3)}");

	// C# 10.0: Lambda 支援記錄型別應用
	var numbers = Enumerable.Range(1, 5);
	var results = numbers.Select(n => new { Number = n, Square = n * n });
	foreach (var result in results)
	{
		Console.WriteLine($"Number: {result.Number}, Square: {result.Square}");
	}

	//2. 迭代器原理與實作
	foreach (var number in GenerateNumbers(5))
	{
		Console.WriteLine(number);
	}
}

// 迭代器方法：逐步返回數字
static IEnumerable<int> GenerateNumbers(int count)
{
	for (int i = 1; i <= count; i++)
	{
		yield return i; // 每次執行時返回當前值，然後暫停
		Thread.Sleep(1000);
	}
}
