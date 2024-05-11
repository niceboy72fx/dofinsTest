using Dofins.Models;
using System.Net.Sockets;

namespace Dofins.Repositories.IRepo
{
    public interface IintradayRepo
    {
        Task HandleIntradaySocket(Socket client);
        Task<string> GetIntradayNow();
        Task BulkInsertAsync(IEnumerable<IntradayQuote> entities);
        Task IntradayInsertAsync(IntradayQuote entities);
    }
}
