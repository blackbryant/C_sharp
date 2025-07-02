
var builder = WebApplication.CreateBuilder();
builder.Services.AddCors();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapPost("getInvoiceData", async ( HttpRequest request, IHubContext<NotificationHub, IInvoiceHub> hub) =>
{
	var file = request.Form.Files["file"];
	if (file == null || file.Length == 0)
	{
		return Results.BadRequest("未上傳檔案");
	}
	
	Console.WriteLine("已接收到發票，開始辨識..." );

	await Task.Delay(2000); // httpclinet 模擬 OCR 處理中

	// 將檔案轉送到 n8n webhook
	using var memoryStream = new MemoryStream();
	await file.CopyToAsync(memoryStream);
	var fileBytes = memoryStream.ToArray();


	await hub.Clients.All.ShowStatus("解析發票!"+fileBytes.Length);
	

	string fakeResult = "發票號碼: AB12345678\n金額: $890\n日期: 2025-07-02";
	
	await hub.Clients.All.ShowResult(fakeResult);

	return Results.Ok("已處理完成");

});

app.UseCors(p => p.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.MapHub<NotificationHub>("InvoiceHub");

app.Run();

/////////////////////////////////////////// SignalR 正確的開發方式 ////////////


/// <summary>定義一個介面</summary>
public interface IInvoiceHub
{
	Task ShowStatus(string message);
	Task ShowResult(string ocrResult);
}

public sealed class NotificationHub : Hub<IInvoiceHub>
{
	
}




