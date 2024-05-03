using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using Dofins.Models;
using Dofins.DTO.Response;
using System.Net.WebSockets;

namespace Dofins.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RealTimeController : ControllerBase
    {

        [HttpGet(Name = "fireant")]
        public String Get()
        {
            return "Hello World";
        }
    }
    
}