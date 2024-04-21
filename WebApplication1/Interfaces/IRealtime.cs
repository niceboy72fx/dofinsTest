using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IRealtime
    {
        Task<Response> UpdateQuote(String token);
        Task<Response> UpdateIntradayQuote(String token);
        Task<Response> UpdateMarket(String token);
        Task<Response> InvokeUpdateMarket(String token);
        Task<Response> InvokeGetAllQuotes(String token);
        Task<Response> MockStockRealtime(List<IntradayQuote> stockCombine, DateTime dateTime);
    }
}
