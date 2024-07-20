using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;
using Newtonsoft.Json;
using System.Text;


namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _PropertyAmenityStatusTrueByPropertyIdComponentPartial:ViewComponent
    {
       private readonly IHttpClientFactory _httpClientFactory;

        public _PropertyAmenityStatusTrueByPropertyIdComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5001/api/PropertyAmenity?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAppUserByProductId>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}