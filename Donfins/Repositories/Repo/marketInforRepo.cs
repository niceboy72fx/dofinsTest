using Dofins.Context;
using Dofins.Models;
using Dofins.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace Dofins.Repositories.Repo
{
    public class marketInforRepo : ImarketInforRepo
    {
        private HandleDbContext _db;

        public marketInforRepo(HandleDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task HandleMarketInforSocket(Socket client)
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
            var intradayQuotes = await _db.marketInfo
                .Where(quote => quote.Date.Date == currentDay)
                .ToListAsync();
            return JsonConvert.SerializeObject(intradayQuotes);
        }

        public async Task BulkInsertAsync(IEnumerable<IntradayQuote> entities)
        {
            await _db.intradayQuotes.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task InsertAsync(IntradayQuote entities)
        {
            await _db.intradayQuotes.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }
    }
}
