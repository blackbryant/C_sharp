/*
1.列舉 (Enum):
列舉 (Enum)是一種用戶定義的值型別，它提供了一組命名常數，這些常數代表一組相關的值
	
2.旗標式列舉 (Flags Enum)
	旗標式列舉是一種特殊的列舉，它的值可以是多個枚舉成員的組合。
	一個變數可以同時代表多個狀態或選項。在系統設定、權限管理等場景中，旗標式列舉非常有用。

3. 列舉搭配字串用法:
	
	
*/
void Main()
{
	//1.列舉 (Enum):
	Color myColor = Color.Green;
	string colorString = myColor.ToString(); // colorString 為 "Green"
	Console.WriteLine(colorString);
	

	// 2.旗標式列舉 (Flags Enum)
	UserPermissions onwer = UserPermissions.CanWrite | UserPermissions.CanRead;
	UserPermissions admin = UserPermissions.CanWrite | UserPermissions.CanRead | UserPermissions.CanExecute | UserPermissions.CanAdmin;
	
	Console.WriteLine($"擁有者:{onwer}");
	Console.WriteLine($"管理者:{admin}");

	// 檢查用戶是否有管理權限
	bool hasAdminPermission = (admin & UserPermissions.CanAdmin) == UserPermissions.CanAdmin;
	Console.WriteLine($"檢查是否管理者:{hasAdminPermission}");

	//3. 列舉搭配字串用法
	Days day5 = Days.Friday;
	Days day1 = Days.Monday;
	Days day2 = Days.Thursday;
	string description1 = EnumProcessor.GetDescription(day5);
	string description2 = EnumProcessor.GetDescription(day1);
	string description3 = EnumProcessor.GetDescription(day2);
	Console.WriteLine($"字串:{description1}");
	Console.WriteLine($"字串:{description2}");
	Console.WriteLine($"字串:{description3}");

}

public enum Color
{
	Red,
	Green,
	Blue
}

//2.旗標式列舉 (Flags Enum)
[Flags]
public enum UserPermissions
{
	None 	   = 0,   //00
	CanRead    = 1,   //01
	CanWrite   = 2,   //10
	CanExecute = 4,   //100
	CanAdmin   = 8    //1000
}

//3. 列舉搭配字串用法
public enum Days
{
	[Description("星期一")]
	Monday = 1,
	[Description("星期二")]
	Tuesday = 2,
	[Description("星期三")]
	Wednesday = 3,
	[Description("星期四")]
	Thursday = 4,
	[Description("星期五")]
	Friday = 5,
	[Description("星期六")]
	Saturday = 6,
	[Description("星期日")]
	Sunday = 0 

}
//建立反射來的到字串
public  class EnumProcessor 
{
	
	public static string GetDescription<T>(T days)
	{
		var memberInfo = typeof(T).GetMember(days.ToString());
		var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
		var description = ((DescriptionAttribute)attributes[0]).Description;
		return description;
	}

	 
}
