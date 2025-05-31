// 建立IQuyert 和 IEnumerable 範例，
// 使用Asp.net core 
// 建立 Sqlite
/*
  引用套件
  Bogus
  Microsoft.AspNetCore.Builder
  Microsoft.AspNetCore.Http
  Microsoft.AspNetCore.Http.HttpResults
  Microsoft.AspNetCore.Mvc
  Microsoft.Data.Sqlite
  Microsoft.EntityFrameworkCore
  Microsoft.Extensions.DependencyInjection
  System.Threading.Tasks
*/

var builder =  WebApplication.CreateBuilder();


var connection = new  SqliteConnection("DataSource=:memory:")  ;
connection.Open();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlite(connection);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	dbContext.Database.EnsureCreated();

	if (!dbContext.Products.Any()) 
	{
		int index =1 ; 
		var productFake = new Faker<Product>()
		.RuleFor(p=> p.Id , f=> index++)
		.RuleFor(p=> p.Name, f => f.Commerce.ProductName())
		.RuleFor(p=> p.Price , f=> f.Finance.Amount(50,2000))
		.RuleFor(p=> p.CategoryId, f=> f.Random.Int(5,10))
		;
		
		var prodcuts = productFake.Generate(100);
		dbContext.Products.AddRange(prodcuts);
		dbContext.SaveChanges();
	}
}


app.MapGet("/query", () =>
{
	using (var scope = app.Services.CreateScope())
	{	
		var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		dbContext.Database.EnsureCreated();
		List<Product> task = ExecuteQuery(dbContext);
		return Results.Ok(task);
	}
});

app.MapGet("/enumer", () => 
{
	using (var scope = app.Services.CreateScope())
	{
		var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
		dbContext.Database.EnsureCreated();
		List<Product> task = ExecuteEnumer(dbContext);
		return Results.Ok(task);
	}

});

app.Run();

/// <summary> IQuery </summary>
/// 只會在真正執行（例如 ToList()、First()）時，才發送查詢。	
/// LINQ 的運算子（像 Where()、Select()、GroupBy()）會被轉換成底層（如 SQL）的查詢語法。	
List<Product> ExecuteQuery(AppDbContext appDbContext)
{
	IQueryable<Product> query =  appDbContext.Products
									.Where( p=> p.CategoryId.Equals(5))
									.OrderBy(p => p.Name);

	// 直到 ToList() 時，才真正執行 SQL 查詢
	List<Product> products =  query.ToList();
 
	return products;
}

/// <summary> IQuery </summary>
/// 適合在 記憶體內部進行處理（例如陣列、清單、集合）
/// 
List<Product> ExecuteEnumer(AppDbContext appDbContext)
{
	// 先把資料從資料庫撈到記憶體
	List<Product> products = appDbContext.Products.ToList();

	// 在記憶體中用 IEnumerable 處理
	IEnumerable<Product> filteredProducts = products
						.Where(p => p.CategoryId.Equals(5))
						.OrderBy(p => p.Name);
					 

	// 直到 ToList() 時，才真正執行 SQL 查詢
	List<Product> productsInFoodCategory =  filteredProducts.ToList();

	return productsInFoodCategory;

}


public class Product
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
}


public class AppDbContext : DbContext 
{

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
	{}

	public DbSet<Product> Products { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<Product>(entity =>
		{
			entity.HasKey(p => p.Id);
			entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
			entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
			entity.Property(p => p.CategoryId).IsRequired();

		});
	}
	
}
