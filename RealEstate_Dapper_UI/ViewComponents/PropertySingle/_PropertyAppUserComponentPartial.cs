using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;


namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _PropertyAppUserComponentPartial:ViewComponent
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5001/api/AppUser?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetAppUserByProductId>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}