<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>


/*
結構的定義：
1.Struct: 是值型別（Value Type），通常用於小型、輕量的數據結構，以減少堆分配（Heap Allocation），提高性能。
	特性：(1) 適用於 小型、不可變（Immutable） 的數據
		 (2) 避免繼承（因為 struct 不能繼承其他 struct）
		 (3) readonly struct 可防止修改字段，提高效能。
		 (4) 避免包含大量字段，以防止過大的複製成本。
		 (5) 隱含繼承自 System.ValueType： 所有結構都隱含繼承自 System.ValueType
	應用: 防禦性複製（Defensive Copying）=>防止無意的修改

2. Framework 中重要的結構型別：
   (1) Nullable<T> : 結構允許實值型別（例如 int、double、bool）具有 null 值

   (2) ValueTuple : C# 7.0 引入輕量級的結構，主要用來替代 Tuple<T1, T2, ...> 類別，並提供更好的性能，因為 ValueTuple 是 值類型（struct），而 Tuple 是 參考類型（class）。
					ValueTuple、ValueTuple<T1>、ValueTuple<T1, T2>、ValueTuple<T1, T2, T3>..... 最多可包含 8 個元素

   (3) ValueTask 與 ValueTask<T>
		(3.1) ValueTask 和 ValueTask<T> 用來替代 Task<T>，減少堆內存分配，提高 async/await 的性能。
		(3.2) 的主要優勢在於減少堆積分配，從而提高效能與記憶體的配置

   應用: 讀取數據庫緩存、ASP.NET Core Web API 優化


特性			ValueTuple<T>					ValueTask<T>
類型		值類型 (struct)					值類型 (struct)
主要用途	存儲多個數據					高效的異步返回
性能優勢	低內存分配，不需要 GC			避免不必要的 Task<T> 分配
適用場景	返回多個值（如方法返回）		小型、頻繁的異步操作

*常見問題:
1.Task<T> 和 ValueTask<T> 有什麼區別？
 Task<T>: 總是分配 堆內存，會觸發 GC、長時間運行的異步操作
 ValueTask<T>: 不必要的堆分配，如果結果可立即獲取，就直接返回結果、高頻調用的小型異步操作，如 緩存查詢


2.ValueTask<T> 什麼時候應該使用？
適合使用： 結果經常已知（如從緩存中讀取數據）、高頻短期異步調用（如 I/O 讀取）。
不適合使用: 需要多次 await，因為 ValueTask<T> 不可重用

*/
void Main()
{
	// Nullable<T> 例子
	int? nullableInt = null;
	
	if (nullableInt.HasValue)
	{
	    Console.WriteLine($"Value: {nullableInt.Value}");
	}
	else
	{
	    Console.WriteLine("No value assigned.");
	}
	
	
	Point p1 = new Point(10, 12);
	//p1.X = 12;  //修改無效
	//Console.WriteLine(((MutableStruct)obj).Value); // 還是 10
	
	//ValueTask 範例
	CacheService cacheService = new CacheService();
	ValueTask<string> valueTask = cacheService.GetDataAsync(10);
	Console.WriteLine($"{valueTask.Result}");
	
	//ValueTuple 範例
	(int Id, string Name) namedPerson = (2, "Bob");
	Console.WriteLine($"{namedPerson.Id}, {namedPerson.Name}");
	
	// 透過解構 (Deconstruction) 訪問值
	var (id, name) = namedPerson;
	Console.WriteLine($"{id}, {name}");
	
	 
}


// struct 例子
public readonly struct Point
{
	public int X { get; }
	public int Y { get; }

	public Point(int x, int y)
	{
		X = x;
		Y = y;
	}
}

public class CacheService
{
	private readonly Dictionary<int, string> _cache = new();

	public ValueTask<string> GetDataAsync(int key)
	{
		if (_cache.TryGetValue(key, out var value))
		{
			return new ValueTask<string>(value);
		}

		return new ValueTask<string>(FetchFromDatabaseAsync(key));
	}

	private async Task<string> FetchFromDatabaseAsync(int key)
	{
		await Task.Delay(500); // 模擬數據庫讀取
		return "DB Result";
	}
}
