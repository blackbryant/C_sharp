// 直接呼叫Ｈｕｂ


var builder = WebApplication.CreateBuilder();
builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();


app.UseCors(p => p.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.MapHub<NotificationHub>("MessageHub");

app.Run();

/////////////////////////////////////////// SignalR 正確的開發方式 ////////////


public sealed class NotificationHub : Hub
{
	//第一個範例
	public async Task SendMessage(string text)  //connection.invoke("SendMessage",  message)
	{
		string filterText = Regex.Replace(text, @"\D", ""); // \D 表示「非數字」
		
		await Clients.All.SendAsync("ReceiveMessage",filterText); // connection.on("ReceiveMessage", (message) => {
		Console.WriteLine(text);

	}
}




