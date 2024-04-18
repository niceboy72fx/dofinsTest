using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        

        [HttpGet(Name = "fireant")]
        public async Task<String> Get()
        {
            Authentication responseContent = new Authentication();
            String messages = "";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var postData = new
                    {
                        email = "dolphindofin@gmail.com",
                        password = "Nvtrung@81",
                    };
                    string jsonContent = JsonConvert.SerializeObject(postData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync("https://www.fireant.vn/api/Data/Login/Login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = await response.Content.ReadAsStringAsync();
                        JObject jsonObject = JsonConvert.DeserializeObject<JObject>(data);
                        responseContent.Token = jsonObject["Token"]?.ToString();
                        responseContent.AccessToken = jsonObject["AccessToken"]?.ToString();
                        responseContent.ErrorMessages = jsonObject["ErrorMessage"]?.ToString();

                    }
                    else
                    {
                        Console.WriteLine($"Failed to post data: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            var hubConnection = new HubConnection("https://www.fireant.vn/", $"Token {responseContent.Token}");

            hubConnection.TraceLevel = TraceLevels.All;
            hubConnection.TraceWriter = Console.Out;

            IHubProxy chatHubProxy = hubConnection.CreateHubProxy("AppQuoteHub");

            chatHubProxy.On<string>("getAllMarkets", messageIR =>
            {
                Console.WriteLine(messageIR);
            });

            try
            {
                await hubConnection.Start();
                messages = "Connection started...";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            /*       await chatHubProxy.Invoke("Send", "Hello, server!").ContinueWith(task =>
                   {
                       if (task.IsFaulted)
                       {
                           Console.WriteLine($"Error invoking Send: {task.Exception.GetBaseException()}");
                       }
                       else
                       {
                           Console.WriteLine("Message sent to server.");
                       }
                   });*/

            return messages;
        }
    }
    
}