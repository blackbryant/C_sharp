void Main()
{
	
	int a =10 ; 
	string b ="hello" ;
	float c = 10.1f; 
	ISerivce d = new WifiSerivce();
	
	ServiceLocator.RegisterSerivce(a);
	ServiceLocator.RegisterSerivce(b);
	ServiceLocator.RegisterSerivce(c);
	ServiceLocator.RegisterSerivce(d);
	ServiceLocator.TraceServices();
	Console.WriteLine(ServiceLocator.GetService<int>());
}

//Service Locator
public static class ServiceLocator 
{
	private static readonly Dictionary<Type, object> _services = new Dictionary<System.Type, object>();

	public static void RegisterSerivce<T>(T service) 
	{
		var type = typeof(T);
		if (!_services.ContainsKey(type))
		{
			_services.Add(type, service);
		}
		
	}

	public static void TraceServices()
	{
		 

		foreach (KeyValuePair<Type, object> kvp in _services)
		{
			string[] trace = {kvp.Key.ToString(),kvp.Value.ToString()} ;
			
			 
			Console.WriteLine($"{trace[0]},{trace[1]}") ; 
		}
		 
	}
	
	public static T GetService<T>() 
	{
		var type = typeof(T);

		if (_services.TryGetValue(type, out var service)) 
		{
			return (T)service;
		}
		 throw new Exception($"Service of type {type.Name} not registered.");
	}
}



public interface ISerivce {

	public string SerivceName {get;set;}
	public void Execute();
	
}

public class WifiSerivce : ISerivce
{
	public string SerivceName {get ; private set;}
	
	string ISerivce.SerivceName { get => SerivceName; set => SerivceName = value ; }

	public WifiSerivce() 
	{
		this.SerivceName = "WIFI" ; 
	}
	
	public void Execute()
	{
		Console.WriteLine($"執行: {SerivceName}");
	}
}


public class GPSSerivce : ISerivce
{
	public string SerivceName { get; private set; }

	string ISerivce.SerivceName { get => SerivceName; set => SerivceName = value; }

	public GPSSerivce()
	{
		this.SerivceName = "GPS";
	}

	public void Execute()
	{
		Console.WriteLine($"執行: {SerivceName}");
	}
}



