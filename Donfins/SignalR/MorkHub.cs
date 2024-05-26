using Dofins.Interfaces;
using Dofins.Models;
using Microsoft.AspNetCore.SignalR;

namespace Dofins.SignalR
{
    public class MorkHub : Hub
    {
        private readonly IRealtime _realtime;
        public MorkHub( IRealtime realtime)
        {
            _realtime = realtime;
        }
       
        

        public override async Task OnConnectedAsync()
        {
            
                while (true)
                {
                    List<QuoteChanges> stockFilter = new List<QuoteChanges> { };
                    var data = _realtime.FilterStockByDate(stockFilter);
                    await Clients.All.SendAsync("updateQuote", data);
                    data.Clear();
                    await Task.Delay(TimeSpan.FromMilliseconds(1200)); // Adjust the delay as needed
                }
        }



    }
}
