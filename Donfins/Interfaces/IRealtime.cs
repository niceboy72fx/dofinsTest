using Dofins.DTO.Response;
using Dofins.Models;

namespace Dofins.Interfaces
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
