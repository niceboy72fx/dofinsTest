using Dofins.Context;
using Dofins.Models;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json;
using Dofins.Repositories.IRepo;


namespace Dofins.Repositories.Repo
{
    public class intradayRepo : IintradayRepo
    {
        readonly HandleDbContext _db;

        public intradayRepo(HandleDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task HandleIntradaySocket(Socket client)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int bytesRead = await client.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                string request = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                string[] parts = request.Split(':');
                string operation = parts[0];
                string data = parts[1];

                string response = await GetIntradayNow();

                byte[] responseBytes = Encoding.ASCII.GetBytes(response);
                await client.SendAsync(responseBytes, SocketFlags.None);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<string> GetIntradayNow()
        {
            DateTime currentDay = DateTime.Now.Date;
            var intradayQuotes = await _db.intradayQuotes
                .Where(quote => quote.Date.Date == currentDay)
                .ToListAsync();
            return JsonConvert.SerializeObject(intradayQuotes);
        }

        public async Task BulkInsertAsync(IEnumerable<IntradayQuote> entities)
        {
            Console.WriteLine("test");
            await _db.intradayQuotes.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task IntradayInsertAsync(IntradayQuote entities)
        {
            await _db.intradayQuotes.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }


    }
}
