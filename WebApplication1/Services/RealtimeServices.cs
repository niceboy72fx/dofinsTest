using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System.Net;
using WebApplication1.DTO.Response;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class RealtimeServices : IRealtime
    {

        List<String> symbols = new List<string> { "CDC", "CTD", "DIG", "FTS", "GMD", "HAX", "KSB", "LPB", "NVL", "SSI", "SZC", "VIC", "VIX", "VND", "CEO", "HUT", "IDC" };


        public async Task<Response<IntradayQuote>> MockStockRealtime(List<IntradayQuote> stockCombine, DateTime dateTime)
        {

            List<IntradayQuote> stockFilter = new List<IntradayQuote> { };
            Console.WriteLine(dateTime.ToString());
            foreach (IntradayQuote stock in stockCombine)
            {
                if (stock.Date == dateTime)
                {
                    stockFilter.Add(stock);
                }
            }
            return new Response<IntradayQuote>(HttpStatusCode.OK, "FireAnt's RealTime", stockFilter);
        }

        public async Task<Response<QuoteChanges>> UpdateQuote(String token)
        {
            List<QuoteChanges> stockCombine = new List<QuoteChanges> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");

            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("updateQuote", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<QuoteChanges> stocks = JsonConvert.DeserializeObject<List<QuoteChanges>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            if (symbols.Contains(stock.Symbol))
                            {
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
                return new Response<QuoteChanges>(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response<QuoteChanges>(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }
            return new Response<QuoteChanges>(HttpStatusCode.OK, "Mock's RealTime", stockCombine);
        }

        public async Task<Response<IntradayQuote>> UpdateIntradayQuote(String token)
        {
            List<IntradayQuote> stockCombine = new List<IntradayQuote> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");

            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("updateIntradayQuote", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<IntradayQuote> stocks = JsonConvert.DeserializeObject<List<IntradayQuote>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            if (symbols.Contains(stock.Symbol))
                            {
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
                return new Response<IntradayQuote>(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response<IntradayQuote>(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }
            return new Response<IntradayQuote>(HttpStatusCode.OK, "Mock's RealTime", stockCombine);
        }


        public async Task<Response<MarketInfoChanges>> UpdateMarket(String token)
        {

            List<MarketInfoChanges> stockCombine = new List<MarketInfoChanges> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");
            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;
            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("updateMarket", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<MarketInfoChanges> stocks = JsonConvert.DeserializeObject<List<MarketInfoChanges>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            stockCombine.Add(stock);
                        }
                    }
                    else
                    {
                        Console.WriteLine("error!");
                    }
                });
            }
            catch (Exception e)
            {
                return new Response<MarketInfoChanges>(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response<MarketInfoChanges>(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }

            return new Response<MarketInfoChanges>(HttpStatusCode.OK, "updateMarket", stockCombine);
        }


        public async Task<Response<MarketInfoChanges>> InvokeUpdateMarket(String token)
        {
            List<MarketInfoChanges> stockCombine = new List<MarketInfoChanges> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");

            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                var messageIR = await chatHubProxy.Invoke<string>("getAllMarkets");
                if (messageIR != null)
                {
                    List<MarketInfoChanges> stocks = JsonConvert.DeserializeObject<List<MarketInfoChanges>>(messageIR);
                    foreach (var stock in stocks)
                    {
                        stockCombine.Add(stock); 
                    }
                }
                else
                {
                    Console.WriteLine("Received empty message for MarketInfoChanges.");
                }
            }
            catch (Exception e)
            {
                return new Response<MarketInfoChanges>(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response<MarketInfoChanges>(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }
            return new Response<MarketInfoChanges>(HttpStatusCode.OK, "Mock's RealTime", stockCombine);
        }


        public async Task<Response<QuoteChanges>> InvokeGetAllQuotes(String token)
        {
            List<QuoteChanges> stockCombine = new List<QuoteChanges> { };
            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");

            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("getAllQuotes", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<QuoteChanges> stocks = JsonConvert.DeserializeObject<List<QuoteChanges>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {              
                                stockCombine.Add(stock);
    
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
                return new Response<QuoteChanges>(HttpStatusCode.BadGateway, $"Error: {e}", null);
            }
            try
            {
                await hubConnection.Start();
            }
            catch (Exception ex)
            {
                return new Response<QuoteChanges>(HttpStatusCode.BadGateway, $"Error: {ex.Message}", null);
            }
            return new Response<QuoteChanges>(HttpStatusCode.OK, "Mock's RealTime", stockCombine);
        }

        public async Task<ResponseAll<QuoteChanges, MarketInfoChanges, IntradayQuote>> FireAnt(String token)
        {
            List<QuoteChanges> quoteChanges = new List<QuoteChanges> { };
            List<MarketInfoChanges> marketInforChange = new List<MarketInfoChanges> { };
            List<IntradayQuote> intradayQuote = new List<IntradayQuote> { };


            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {token}");
            ServicePointManager.DefaultConnectionLimit = 200;
            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");
            try
            {
                chatHubProxy.On("updateQuote", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<QuoteChanges> stocks = JsonConvert.DeserializeObject<List<QuoteChanges>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            quoteChanges.Add(stock);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received empty message.");
                    }
                });
                chatHubProxy.On("updateMarket", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<MarketInfoChanges> stocks = JsonConvert.DeserializeObject<List<MarketInfoChanges>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            marketInforChange.Add(stock);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received empty message.");
                    }
                });
                chatHubProxy.On("updateIntradayQuote", messageIR =>
                {
                    if (messageIR != null)
                    {
                        List<IntradayQuote> stocks = JsonConvert.DeserializeObject<List<IntradayQuote>>(messageIR.ToString());
                        foreach (var stock in stocks)
                        {
                            intradayQuote.Add(stock);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Received empty message.");
                    }
                });
                var messageIR = await chatHubProxy.Invoke<string>("getAllMarkets");
                if (messageIR != null)
                {
                    List<MarketInfoChanges> stocks = JsonConvert.DeserializeObject<List<MarketInfoChanges>>(messageIR);
                    foreach (var stock in stocks)
                    {
                        marketInforChange.Add(stock);
                    }
                }
                else
                {
                    Console.WriteLine("Received empty message for MarketInfoChanges.");
                }
            }
            catch (Exception ex)
            {
                return new ResponseAll<QuoteChanges, MarketInfoChanges, IntradayQuote>(HttpStatusCode.OK, "Couldn't fetching !" + ex, null, null, null);
            }
            try
            {
                await hubConnection.Start();
            } catch (Exception ex)
            {
                return new ResponseAll<QuoteChanges, MarketInfoChanges, IntradayQuote>(HttpStatusCode.OK, "Couldn't fetching !" + ex, null, null, null);
            }
            return new ResponseAll<QuoteChanges, MarketInfoChanges, IntradayQuote>(HttpStatusCode.OK, "FireAnt's RealTime", quoteChanges, marketInforChange, intradayQuote);
        }
    }
}
