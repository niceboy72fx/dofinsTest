using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;
using WebApplication1.DTO.Response;
using System.Net.WebSockets;

namespace WebApplication1.Controllers
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