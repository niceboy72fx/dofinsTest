using Dofins.Models;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace Dofins.Repositories.IRepo
{
    public interface IquoteChangesRepo
    {
          Task HandleMarketInforSocket(Socket client);
          Task<string> GetQuoteChange();
          Task BulkInsertAsync(IEnumerable<QuoteChanges> entities);
          Task InsertAsync(QuoteChanges entities);
    }
}
