using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region İstatistik1 - ToplamIlanSayısı
            var client1 =_httpClientFactory.CreateClient();
            var responeseMessage1=await client1.GetAsync("http://localhost:5001/api/Statistics/ProductCount");
            var jsonData1=await responeseMessage1.Content.ReadAsStringAsync();
            ViewBag.ProductCount=jsonData1;
            #endregion

            #region İstatistik2 - EnBaşarılıPersonel
            var client2 =_httpClientFactory.CreateClient();
            var responeseMessage2=await client2.GetAsync("http://localhost:5001/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2=await responeseMessage2.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount=jsonData2;
            #endregion

            #region İstatistik3
            var client3 =_httpClientFactory.CreateClient();
            var responeseMessage3=await client3.GetAsync("http://localhost:5001/api/Statistics/DifferentCityCount");
            var jsonData3=await responeseMessage3.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount=jsonData3;
            #endregion

            #region İstatistik4
            var client4 =_httpClientFactory.CreateClient();
            var responeseMessage4=await client4.GetAsync("http://localhost:5001/api/Statistics/CategoryCount");
            var jsonData4=await responeseMessage4.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount=jsonData4;
            #endregion

            return View();

        }

    }
}