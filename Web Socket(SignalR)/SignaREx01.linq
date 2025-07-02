//使用 api 來呼叫Hub

var builder = WebApplication.CreateBuilder();
builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapPost("putOrder", async ([FromBody]string text,IHubContext<NotificationHub,INotificationHub> hub) => {
	
	await hub.Clients.All.SendMessage(text) ;
	
	Console.WriteLine("回傳訊息!"+text);
	return Results.Ok("成功!!!");

});

app.UseCors(p=> p.SetIsOriginAllowed(_=>true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.MapHub<NotificationHub>("MessageHub");

app.Run();

/////////////////////////////////////////// SignalR 正確的開發方式 ////////////


/// <summary>定義一個介面</summary>
public interface INotificationHub 
{
	Task SendMessage(string message);
	 
}


public sealed class NotificationHub : Hub<INotificationHub>
{
	//第一個範例
	public async Task SendMessage(string text)  //connection.invoke("SendMessage",  message)
	{
		await Clients.All.SendMessage(text); // connection.on("ReceiveMessage", (message) => {
		Console.WriteLine(text);
		
	}
}




