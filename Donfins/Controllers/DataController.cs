using Dofins.Services;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Dofins.Controllers
{
    [Route("/")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private  ApiService _apiService;
        private RealtimeServices _realtimeServices;
        private DataController(ApiService apiService, RealtimeServices realtimeServices) { _apiService = apiService; realtimeServices = _realtimeServices; }

        [HttpGet]
        [Route("/intradayHistory")]
        public async Task<String> GetIntradayHistory()
        {
            
            return "Success";
        }
    }
}
