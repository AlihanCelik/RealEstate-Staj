using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
         private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            #region İstatistik1
            var client =_httpClientFactory.CreateClient();
            var responeseMessage=await client.GetAsync("http://localhost:5001/api/Statistics/ActiveCategoryCount");
            var jsonData=await responeseMessage.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount=jsonData;
            #endregion

            #region İstatistik2
            var client2 =_httpClientFactory.CreateClient();
            var responeseMessage2=await client2.GetAsync("http://localhost:5001/api/Statistics/ActiveEmployeeCount");
            var jsonData2=await responeseMessage2.Content.ReadAsStringAsync();
            ViewBag.ActiveEmployeeCount=jsonData2;
            #endregion

            #region İstatistik5
            var client5 =_httpClientFactory.CreateClient();
            var responeseMessage5=await client5.GetAsync("http://localhost:5001/api/Statistics/ApartmentCount");
            var jsonData5=await responeseMessage5.Content.ReadAsStringAsync();
            ViewBag.ApartmentCount=jsonData5;
            #endregion

            #region İstatistik6
            var client6 =_httpClientFactory.CreateClient();
            var responeseMessage6=await client6.GetAsync("http://localhost:5001/api/Statistics/AverageProductPriceBySale");
            var jsonData6=await responeseMessage6.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceBySale=jsonData6;
            #endregion


            #region İstatistik7
            var client7 =_httpClientFactory.CreateClient();
            var responeseMessage7=await client7.GetAsync("http://localhost:5001/api/Statistics/AverageProductPriceByRent");
            var jsonData7=await responeseMessage7.Content.ReadAsStringAsync();
            ViewBag.AverageProductPriceByRent=jsonData7;
            #endregion


            #region İstatistik8
            var client8 =_httpClientFactory.CreateClient();
            var responeseMessage8=await client8.GetAsync("http://localhost:5001/api/Statistics/AverageRoomCount");
            var jsonData8=await responeseMessage8.Content.ReadAsStringAsync();
            ViewBag.AverageRoomCount=jsonData8;
            #endregion

            #region İstatistik9
            var client9 =_httpClientFactory.CreateClient();
            var responeseMessage9=await client9.GetAsync("http://localhost:5001/api/Statistics/CategoryCount");
            var jsonData9=await responeseMessage9.Content.ReadAsStringAsync();
            ViewBag.ActiveCategoryCount=jsonData9;
            #endregion


            #region İstatistik10
            var client10 =_httpClientFactory.CreateClient();
            var responeseMessage10=await client10.GetAsync("http://localhost:5001/api/Statistics/CategoryNameByMaxProductByRent");
            var jsonData10=await responeseMessage10.Content.ReadAsStringAsync();
            ViewBag.CategoryNameByMaxProductByRent=jsonData10;
            #endregion

            #region İstatistik11
            var client11 =_httpClientFactory.CreateClient();
            var responeseMessage11=await client11.GetAsync("http://localhost:5001/api/Statistics/CityNameByMaxProductCount");
            var jsonData11=await responeseMessage11.Content.ReadAsStringAsync();
            ViewBag.CityNameByMaxProductCount=jsonData11;
            #endregion


            #region İstatistik12
            var client12 =_httpClientFactory.CreateClient();
            var responeseMessage12=await client12.GetAsync("http://localhost:5001/api/Statistics/DifferentCityCount");
            var jsonData12=await responeseMessage12.Content.ReadAsStringAsync();
            ViewBag.DifferentCityCount=jsonData12;
            #endregion

            #region İstatistik13
            var client13 =_httpClientFactory.CreateClient();
            var responeseMessage13=await client13.GetAsync("http://localhost:5001/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData13=await responeseMessage13.Content.ReadAsStringAsync();
            ViewBag.EmployeeNameByMaxProductCount=jsonData13;
            #endregion

            #region İstatistik14
            var client14 =_httpClientFactory.CreateClient();
            var responeseMessage14=await client14.GetAsync("http://localhost:5001/api/Statistics/LastProductPrice");
            var jsonData14=await responeseMessage14.Content.ReadAsStringAsync();
            ViewBag.LastProductPrice=jsonData14;
            #endregion

            #region İstatistik15
            var client15 =_httpClientFactory.CreateClient();
            var responeseMessage15=await client15.GetAsync("http://localhost:5001/api/Statistics/NewestBuildingYear");
            var jsonData15=await responeseMessage15.Content.ReadAsStringAsync();
            ViewBag.NewestBuildingYear=jsonData15;
            #endregion

            #region İstatistik16
            var client16 =_httpClientFactory.CreateClient();
            var responeseMessage16=await client16.GetAsync("http://localhost:5001/api/Statistics/OldestBuildingYear");
            var jsonData16=await responeseMessage16.Content.ReadAsStringAsync();
            ViewBag.OldestBuildingYear=jsonData16;
            #endregion

            #region İstatistik17
            var client17 =_httpClientFactory.CreateClient();
            var responeseMessage17=await client17.GetAsync("http://localhost:5001/api/Statistics/PassiveCategoryCount");
            var jsonData17=await responeseMessage17.Content.ReadAsStringAsync();
            ViewBag.PassiveCategoryCount=jsonData17;
            #endregion

            #region İstatistik18
            var client18 =_httpClientFactory.CreateClient();
            var responeseMessage18=await client18.GetAsync("http://localhost:5001/api/Statistics/ProductCount");
            var jsonData18=await responeseMessage18.Content.ReadAsStringAsync();
            ViewBag.ProductCount=jsonData18;
            #endregion




            return View();
        }
    }
}