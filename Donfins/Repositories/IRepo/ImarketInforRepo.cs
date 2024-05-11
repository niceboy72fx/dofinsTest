using Dofins.Models;
using System.Net.Sockets;

namespace Dofins.Repositories.IRepo
{
    public interface ImarketInforRepo
    {
        Task HandleMarketInforSocket(Socket client);
        Task InsertAsync(IntradayQuote entities);
        Task BulkInsertAsync(IEnumerable<IntradayQuote> entities);
        Task<string> GetIntradayNow();

    }
}
