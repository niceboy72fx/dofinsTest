using Dofins.Models;

namespace Dofins.Interfaces
{
    public interface IRealtime
    {
        List<QuoteChanges> FilterStockByDate(List<QuoteChanges> stockFilter);
    }
}
