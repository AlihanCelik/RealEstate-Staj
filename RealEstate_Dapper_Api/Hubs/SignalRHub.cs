using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task SendCategoryCount()
        {
            var client =_httpClientFactory.CreateClient();
            var responeseMessage=await client.GetAsync("http://localhost:5001/api/Statistics/CategoryCount");
            var jsonData=await responeseMessage.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCategoryCount",jsonData);
        }
    }
}