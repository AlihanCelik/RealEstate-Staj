using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;
namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
         private readonly IHttpClientFactory _httpClientFactory;
         private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory,ILoginService loginService)
        {
            _httpClientFactory=httpClientFactory;
            _loginService=loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id=_loginService.GetUserId;
            #region İstatistik1 - ToplamIlanSayısı
            var client1 =_httpClientFactory.CreateClient();
            var responeseMessage1=await client1.GetAsync("http://localhost:5001/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1=await responeseMessage1.Content.ReadAsStringAsync();
            ViewBag.AllProductCount=jsonData1;
            #endregion

            #region İstatistik2 - EmlakçınınİlanSayısı
            var client2 =_httpClientFactory.CreateClient();
            var responeseMessage2=await client2.GetAsync("http://localhost:5001/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+id);
            var jsonData2=await responeseMessage2.Content.ReadAsStringAsync();
            ViewBag.ProductCountByEmployeeId=jsonData2;
            #endregion

            #region İstatistik3 - EmlakçınınPasifİlanSayısı
            var client3 =_httpClientFactory.CreateClient();
            var responeseMessage3=await client3.GetAsync("http://localhost:5001/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
            var jsonData3=await responeseMessage3.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusFalse=jsonData3;
            #endregion

            #region İstatistik4 - EmlakçınınAktifİlanSayısı
            var client4 =_httpClientFactory.CreateClient();
            var responeseMessage4=await client4.GetAsync("http://localhost:5001/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
            var jsonData4=await responeseMessage4.Content.ReadAsStringAsync();
            ViewBag.ProductCountByStatusTrue=jsonData4;
            #endregion

            return View();

        }


    }
}