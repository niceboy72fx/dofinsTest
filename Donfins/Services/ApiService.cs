using Dofins.DTO.Response;
using Dofins.Models;
using Microsoft.AspNet.SignalR.Client.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;

namespace Dofins.Services{
    public class ApiService
    {
        public async void FetchHistoryIntradayQuote(String token, String symbols)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add("JWTToken", token);
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync("https://www.fireant.vn/api/Excel/Market/IntradayQuotes/" + symbols);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(data);
}
                     else { 
                        Console.WriteLine($"Failed to post data: {response.StatusCode} - {response.ReasonPhrase}");
                     }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
