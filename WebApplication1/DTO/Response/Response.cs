using System.Net;
using WebApplication1.Models;

namespace WebApplication1.DTO.Response
{
    public class Response
    {
        public HttpStatusCode Status  { get; set; }
        public string Message { get; set; }
        public List<IntradayQuote> Data { get; set; }


        public Response(HttpStatusCode Status, string Message, List<IntradayQuote> Data)
        {
            this.Status = Status;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
