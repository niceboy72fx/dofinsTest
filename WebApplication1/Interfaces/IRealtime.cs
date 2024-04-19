using WebApplication1.DTO.Response;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface IRealtime
    {
        Task<Response> FireAntRealTime(String token);
        Task<Response> MockStockRealtime(List<Stock> stockCombine, DateTime dateTime);
    }
}
