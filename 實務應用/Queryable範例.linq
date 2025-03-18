/*
   LINQ to SQL 查詢效能不彰，要需透過 SQL Server Profiler 分析實際執行的 T-SQL 語法）
   
   
   
*/
void Main()
{
	Console.WriteLine($"===========IEnumerable===========");
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	
	//將回傳的資料抽象化，所以改用 IEnumerable<T> 型別回傳
	//兩次執行 Count() 查詢時都沒有最佳化，而是將所有資料都回傳回來變成 Entity 物件後才對這些物件進行彙整運算。
	TypedDataContext context = new TypedDataContext();
	context.EnableLINQPadLogging() ;

	//轉成SQL:SELECT [u].[id], [u].[address], [u].[city], [u].[email], [u].[firstName], [u].[gender], [u].[lastName], [u].[phone]
	//        FROM[UserInfo] AS[u]
	var all = GetUserInfos(context);
	Console.WriteLine("SQL:"+GetUserInfos(context) );
	Console.WriteLine("Total Rows: " + all.Count());

	//轉成SQL:SELECT [u].[id], [u].[address], [u].[city], [u].[email], [u].[firstName], [u].[gender], [u].[lastName], [u].[phone]
	//        FROM[UserInfo] AS[u]
	var page1 = all.Where(p => p.LastName == "Swift");
	Console.WriteLine("Total Rows: " + page1.Count());


	stopwatch.Stop();
	TimeSpan elapsedTime = stopwatch.Elapsed;
	Console.WriteLine($"執行時間：{elapsedTime.TotalMilliseconds} 毫秒");

	Console.WriteLine($"===========Queryable===========");
	Stopwatch stopwatch2 = new Stopwatch();
	stopwatch2.Start();

	//轉成SQL:SELECT COUNT(*) FROM [UserInfo] AS [u]
	var queryAll = GetUserInfos(context).AsQueryable();
	Console.WriteLine("Total Rows: " + queryAll.Count());

	//轉成SQL: SELECT COUNT(*) FROM[UserInfo] AS[u] WHERE[u].[lastName] = N'Swift'
	//取回結果的時候AsQueryable() 擴充方法將結果轉型成 IQueryable<T> 型別
	var page2 = queryAll.Where(p => p.LastName == "Swift").AsQueryable();
	Console.WriteLine("Total Rows: " + page2.Count());
	Console.WriteLine("First Rows: " + page2.ToList()[0].LastName);

	stopwatch2.Stop();
	TimeSpan elapsedTime2 = stopwatch2.Elapsed;
	Console.WriteLine($"執行時間：{elapsedTime2.TotalMilliseconds} 毫秒");

}

private static IEnumerable<UserInfo> GetUserInfos( TypedDataContext context) 
{

	return context.UserInfo  ;
	
}


