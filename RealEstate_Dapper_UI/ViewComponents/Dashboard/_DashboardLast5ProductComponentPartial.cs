using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.Das
{
    public class _DashboardLast5ProductComponentPartial:ViewComponent
    {
         private readonly IHttpClientFactory _httpClientFactory;
        public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage= await client.GetAsync("http://localhost:5001/api/Products/GetLast5ProductAsync");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}