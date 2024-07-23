using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.SubFeatureDtos;


namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultSubFeatureComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSubFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cleint=_httpClientFactory.CreateClient();
            var responeseMessage=await cleint.GetAsync("http://localhost:5001/api/SubFeature");
            if(responeseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responeseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultSubFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}