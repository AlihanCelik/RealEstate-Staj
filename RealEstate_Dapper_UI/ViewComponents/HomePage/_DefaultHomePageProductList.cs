using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultHomePageProductList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultHomePageProductList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cleint=_httpClientFactory.CreateClient();
            var responeseMessage=await cleint.GetAsync("http://localhost:5001/api/Products/GetProductByDealOfTheDayTrueWithCategoryAsync");
            if(responeseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responeseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}