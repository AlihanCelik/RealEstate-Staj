using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;


namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _PropertySliderComponentPartial:ViewComponent
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public _PropertySliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5001/api/ProductImage/GetProductImageByProductId?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetProductImageByProductIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}