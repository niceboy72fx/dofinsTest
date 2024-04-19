using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
using WebApplication1.DTO.Response;
using System.Net.WebSockets;
using WebApplication1.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WebApplication1.Interfaces;
using System.Linq;

namespace WebApplication1.Services
{
    public class RealtimeServices : IRealtime
    {

        List<String> symbols = new List<string> { "CDC", "CTD", "DIG", "FTS", "GMD", "HAX", "KSB", "LPB", "NVL", "SSI", "SZC", "VIC", "VIX", "VND", "CEO", "HUT", "IDC" };


        public async Task<Response> MockStockRealtime(List<Stock> stockCombine, DateTime dateTime) {

            List<Stock> stockFilter = new List<Stock> { };            
            Console.WriteLine(dateTime.ToString());
            foreach (Stock stock in stockCombine)
            {
                if (stock.Date == dateTime)
                {
                    stockFilter.Add(stock);
                }
            }
            return new Response(HttpStatusCode.Accepted, "FireAnt's RealTime", stockFilter);
        }

        public async Task<Response> FireAntRealTime(String token)
        {
            List<Stock> stockCombine = new List<Stock> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");

            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("updateIntradayQuote", messageIR =>
                {
                    if (!string.IsNullOrEmpty(messageIR))
                    {
                        List<Stock> stocks = JsonConvert.DeserializeObject<Stock>(messageIR);
                        foreach (var stock in stocks)
                        {
                            if (symbols.Contains(stock.Symbol))
                            {
                                Console.WriteLine($"ID: {stock.ID}");
                                Console.WriteLine($"Symbol: {stock.Symbol}");
                                Console.WriteLine($"Date: {stock.Date}");
                                Console.WriteLine($"Price: {stock.Price}");
                                Console.WriteLine($"Volume: {stock.Volume}");
                                Console.WriteLine($"TotalVolume: {stock.TotalVolume}");
                                Console.WriteLine($"Side: {stock.Side}");
                                Console.WriteLine("--------------");
                                stockCombine.Add(stock);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received empty message.");
                    }
                });
            }
            catch (Exception e)
            {
                return new Response(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }
            return new Response(HttpStatusCode.Accepted, "Mock's RealTime", stockCombine);
        }
    }
}
