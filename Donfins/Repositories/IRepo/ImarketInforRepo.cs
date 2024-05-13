using Dofins.Models;
using System.Net.Sockets;

namespace Dofins.Repositories.IRepo
{
    public interface ImarketInforRepo
    {
        Task HandleMarketInforSocket(Socket client);
        Task InsertAsync(MarketInfoChanges entities);
        Task BulkInsertAsync(IEnumerable<MarketInfoChanges> entities);
        Task<string> GetUpdateMarket();

    }
}
