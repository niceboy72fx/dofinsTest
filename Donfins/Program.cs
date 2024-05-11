using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Dofins.Interfaces;
using Dofins.Models;
using Dofins.Services;
using Dofins.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.UseUrls("http://localhost:4000");

builder.Services.AddSingleton<IAuthentication, AuthenticationServices>();

builder.Services.AddSingleton<IRealtime, RealtimeServices>();

/*builder.Services.AddDbContext<HandleDbContext>(options => options.UseNpgsql(
          builder.Configuration.GetConnectionString("Postgres")
));
*/

builder.Services.AddSingleton<HandleDbContext>(serviceProvider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<HandleDbContext>();
    optionsBuilder.UseNpgsql(builder.Configuration.GetConnectionString("Postgres"));
    return new HandleDbContext(optionsBuilder.Options);
});

/*builder.Services.AddSingleton<HandleDbContext>();
*/
var app = builder.Build();

app.UseWebSockets();



app.Map("/invokeGetAllQuote", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
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
            while (true)
            {
                var stockServices = await realtimeServices.InvokeGetAllQuotes(token);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
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
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

app.Map("/invokeGetUpdateMarket", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
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
            while (true)
            {
                var stockServices = await realtimeServices.InvokeUpdateMarket(token);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
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
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

app.Map("/updateMarket", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
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
            while (true)
            {
                var stockServices = await realtimeServices.UpdateMarket(token);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
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
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

app.Map("/updateQuote", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
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
            while (true)
            {
                var stockServices = await realtimeServices.UpdateQuote(token);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
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
                }
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});


app.Map("/updateIntradayQuote", async context =>
{

    if (context.WebSockets.IsWebSocketRequest)
    {
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
            while (true)
            {
                var stockServices = await realtimeServices.UpdateIntradayQuote(token);
                if (stockServices.Data != null && stockServices.Data.Count > 0)
                {
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
        var authenticationServices = app.Services.GetRequiredService<IAuthentication>();
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
                var stockServices = await realtimeServices.FireAnt(token);
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
            }
        }
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});


await app.RunAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
