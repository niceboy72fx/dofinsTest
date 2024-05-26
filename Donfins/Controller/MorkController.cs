using Dofins.Interfaces;
using Dofins.Models;
using Dofins.SignalR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Dofins.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class MorkController : ControllerBase
    {
        private readonly IHubContext<MorkHub> _hubContext;
        private readonly IRealtime _realtime;
        

        public MorkController(IHubContext<MorkHub> hubContext, IRealtime realtime)
        {
            _hubContext = hubContext;
            _realtime = realtime;
        }

        [HttpPost]
        public async Task<IActionResult> PostMessage()
        {
            List<QuoteChanges> stockFilter = new List<QuoteChanges> { };
            var data = _realtime.FilterStockByDate(stockFilter);
            await _hubContext.Clients.All.SendAsync("updateQuote",data);
/*            data.Clear();
*/            return Ok();
        }
    }
}
