using Dofins.Context;
using Dofins.Models;
using Dofins.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Text;

namespace Dofins.Repositories.Repo
{
    public class quoteChangesRepo : IquoteChangesRepo
    {
        private HandleDbContext _db;

        public quoteChangesRepo(HandleDbContext dbContext)
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

                string response = await GetQuoteChange();

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

        public async Task<string> GetQuoteChange()
        {
            DateTime currentDay = DateTime.Now.Date;
            var quoteChange = await _db.quoteChanges
                .Where(quote => quote.Date == currentDay)
                .ToListAsync();
            return JsonConvert.SerializeObject(quoteChange);
        }

        public async Task BulkInsertAsync(IEnumerable<QuoteChanges> entities)
        {
            await _db.quoteChanges.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }

        public async Task InsertAsync(QuoteChanges entities)
        {
            await _db.quoteChanges.AddRangeAsync(entities);
            await _db.SaveChangesAsync();
        }
    }
}
