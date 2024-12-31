//DI 設計模式

void Main()
{
	//1. 建構子注入
	IPlugin plugin = new VGAPlugin();
	MotherBoard motherBoard = new MotherBoard(plugin);
	motherBoard.Drive();
	
	//2.方法注入
	IFunction function1 = new SoundEffectFunction();
	IFunction funciton2 = new NetworkFunction();
	
	motherBoard.AddFunction(function1);
	motherBoard.AddFunction(funciton2);
	
	motherBoard.ShowFucntion();

	//3.屬性注入
	IPower power = new SuperPower(2_000);
	motherBoard.power = power ; 
	motherBoard.ShowPower();
	
}

// You can define other methods, fields, classes and namespaces here

//1. 建構子注入
public class MotherBoard
{
	private IPlugin _plugin;


	public MotherBoard(IPlugin plugin)
	{
		if (plugin == null)
		{
			throw new ArgumentNullException(nameof(plugin));
		}

		_plugin = plugin;
	}

	public void Drive()
	{
		_plugin.Execute();
	}

	//2.方法注入
	private List<IFunction> functionList;
	public void AddFunction(IFunction function)
	{
		if (this.functionList is null)
		{
			this.functionList = new List<IFunction>();
		}

		this.functionList.Add(function);
	}

	public void ShowFucntion()
	{
		foreach (IFunction function in functionList)
		{
			function.Feature();
		}
	}

	//3.屬性注入
	public IPower power {set; get;}

	public void ShowPower()
	{
		Console.WriteLine($"Power {power.Power} watt"); 
	}
	
}


//介面IPlugin
public interface IPlugin 
{
	public void Execute() ;
}

//VGA介面實作
public class VGAPlugin : IPlugin
{
	public void Execute()
	{
		Console.WriteLine("Plugin VGA "); 
	}
}

//介面:IFunction
public interface IFunction 
{
	public void Feature();
};

public class SoundEffectFunction : IFunction
{
	public void Feature()
	{
		Console.WriteLine("audio effect enable");
	}
}

public class NetworkFunction : IFunction
{
	public void Feature()
	{
		Console.WriteLine("Network enable");
	}
}

//介面:IPower
public interface IPower 
{
	 int Power {get ;  set ;} 
}

public class SuperPower : IPower
{
	public int Power { get; protected set; }

	int IPower.Power   // Explicit implementation of the interface
	{
		get => Power;
		set => Power = value;
	}

	public SuperPower(int power) 
	{
		this.Power = power ;
		
	}
	 
}

