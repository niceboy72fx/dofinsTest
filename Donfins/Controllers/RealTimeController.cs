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
    [Route("/api/ws")]
    [ApiController]
    public class RealTimeController : ControllerBase
    {
        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnectionManager _connectionManager;

        public RealTimeController(
            IConnectionFactory connectionFactory,
            IConnectionManager connectionManager)
        {
            _connectionFactory = connectionFactory;
            _connectionManager = connectionManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var context = ControllerContext.HttpContext;

            if (context.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                Console.WriteLine($"Accepted connection '{context.Connection.Id}'");
                var connection = _connectionFactory.CreateConnection(webSocket);
                await _connectionManager.HandleConnection(connection);
                return new EmptyResult();
            }
            else
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
        }
    }
}