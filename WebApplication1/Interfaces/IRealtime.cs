using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IRealtime
    {
        Task<Response<QuoteChanges>> UpdateQuote(String token);
        Task<Response<IntradayQuote>> UpdateIntradayQuote(String token);
        Task<Response<MarketInfoChanges>> UpdateMarket(String token);
        Task<Response<MarketInfoChanges>> InvokeUpdateMarket(String token);
        Task<Response<QuoteChanges>> InvokeGetAllQuotes(String token);
        Task<Response<IntradayQuote>> MockStockRealtime(List<IntradayQuote> stockCombine, DateTime dateTime);
        Task<ResponseAll<QuoteChanges, MarketInfoChanges, IntradayQuote>> FireAnt(String token);
    }
}
