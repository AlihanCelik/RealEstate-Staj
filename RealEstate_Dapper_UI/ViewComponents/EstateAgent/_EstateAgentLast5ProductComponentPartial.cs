using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using Newtonsoft.Json;
using System.Text;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
         private readonly ILoginService _loginService;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory,ILoginService loginService)
        {
            _httpClientFactory=httpClientFactory;
            _loginService=loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id=_loginService.GetUserId;
            var cleint=_httpClientFactory.CreateClient();
            var responeseMessage=await cleint.GetAsync("http://localhost:5001/api/EstateAgentLastProducts?id="+id);
            if(responeseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responeseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultLast5ProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}