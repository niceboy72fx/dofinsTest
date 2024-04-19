using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using WebApplication1.DTO.Response;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://localhost:6969");

builder.Services.AddSingleton<IAuthentication, AuthenticationServices>();

builder.Services.AddSingleton<IRealtime, RealtimeServices>();





var app = builder.Build();

app.UseWebSockets();
app.Map("/mockData", async context =>
{
   
    if (context.WebSockets.IsWebSocketRequest)
    {
        string dateString = "2024-04-19T02:15:02.347Z";
       
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        var authenticationServices = app.Services.GetRequiredService<IAuthentication>();
        var realtimeServices = app.Services.GetRequiredService<IRealtime>();
        String token = await authenticationServices.GetTokenFireAnt();
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("Failed to retrieve token.");
        }
        else
        {
            List<Stock> stockCombine = new List<Stock> { };
            List<String> symbols = new List<string> {   "CDC",
  "CTD",
  "DIG",
  "FTS",
  "GMD",
  "HAX",
  "KSB",
  "LPB",
  "NVL",
  "SSI",
  "SZC",
  "VIC",
  "VIX",
  "VND",
  "CEO",
  "HUT",
  "IDC",
  "SHS",
  "VGS",
  "CLX",
  "ANV",
  "BID",
  "CII",
  "CTD",
  "DCM",
  "DGC",
  "DGW",
  "DIG",
  "DPG",
  "DXG",
  "FUEVFVND",
  "GMD",
  "HAG",
  "HDB",
  "HDC",
  "HHV",
  "HPG",
  "HPX",
  "HTN",
  "KHG",
  "KSB",
  "MBB",
  "MSN",
  "NT2",
  "NVL",
  "PDR",
  "PHR",
  "STB",
  "TLH",
  "VIX",
  "VND",
  "VPB",
  "VSC",
  "MFS",
  "VGT",
  "VHG",
  "CTG",
  "VIB",
  "VIC",
  "MBB",
  "SHS",
  "CTG",
  "VIB",
  "VND",
  "SHB",
  "HAG",
  "CTG",
  "VIB",
  "STB",
  "VND",
  "HCM",
  "HDB",
  "MBB",
  "VIB",
  "VND",
  "CTG",
  "SHB",
  "HCM",
  "MBB",
  "VND",
  "HDB",
  "SHB" };
           
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("JWTToken", token);
                try
                {
                    foreach (String symbol in symbols)
                    {

                        HttpResponseMessage response = await httpClient.GetAsync($"https://www.fireant.vn/api/Excel/Market/IntradayQuotes/{symbol}");
                        if (response.IsSuccessStatusCode)
                        {
                            string data = await response.Content.ReadAsStringAsync();
                            List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(data);
                            foreach (Stock stock in stocks)
                            {
                                stockCombine.Add(stock);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            DateTime dateTime = DateTime.ParseExact(dateString, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", System.Globalization.CultureInfo.InvariantCulture);
            string endDate = "2024-04-19T07:45:03.723Z";
            DateTime endDateParser = DateTime.ParseExact(endDate, "yyyy-MM-dd'T'HH:mm:ss.fff'Z'", System.Globalization.CultureInfo.InvariantCulture);
            while (true)
            {
                var stockServices = await realtimeServices.MockStockRealtime(stockCombine, dateTime);
                var message = Newtonsoft.Json.JsonConvert.SerializeObject(stockServices);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
                    var bytes = Encoding.UTF8.GetBytes(message);
                    var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                    if (ws.State == System.Net.WebSockets.WebSocketState.Open)
                    {
                        await ws.SendAsync(arraySegment, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);

                    }
                    else if (ws.State == System.Net.WebSockets.WebSocketState.Closed || ws.State == System.Net.WebSockets.WebSocketState.Aborted)
                    {
                        break;
                    }
                }
                dateTime = dateTime.AddMilliseconds(1);
                if (dateTime >= endDateParser)
                {
                    break;
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});


app.Map("/fireAnt", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        var authenticationServices =  app.Services.GetRequiredService<IAuthentication>();
        var realtimeServices = app.Services.GetRequiredService<IRealtime>();
        String token = await authenticationServices.GetTokenFireAnt();
        if (string.IsNullOrEmpty(token))
        {
            Console.WriteLine("Failed to retrieve token.");
        }
        else
        {
            while (true)
            {
                var stockServices = await realtimeServices.FireAntRealTime(token);
                var message = Newtonsoft.Json.JsonConvert.SerializeObject(stockServices);
                var bytes = Encoding.UTF8.GetBytes(message);
                var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                if (ws.State == System.Net.WebSockets.WebSocketState.Open)
                {
                    await ws.SendAsync(arraySegment, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else if (ws.State == System.Net.WebSockets.WebSocketState.Closed || ws.State == System.Net.WebSockets.WebSocketState.Aborted)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

await app.RunAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
