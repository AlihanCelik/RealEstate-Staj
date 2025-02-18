using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
         private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var cleint=_httpClientFactory.CreateClient();
            var responeseMessage=await cleint.GetAsync("http://localhost:5001/api/Products/ProductListWithCategory");
            if(responeseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responeseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultProductDtos>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId,string city)
        {
            ViewBag.searchKeyValue = TempData["searchKeyValue"];
            ViewBag.propertyCategoryId = TempData["propertyCategoryId"];
            ViewBag.city = TempData["city"];

            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();

			var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5001/api/Products/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);
            }
            return View();

        }
        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            ViewBag.i=id;
             var cleint=_httpClientFactory.CreateClient();
            var responeseMessage=await cleint.GetAsync("http://localhost:5001/api/Products/GetProductByProductId?id="+id);
            var jsonData=await responeseMessage.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<ResultProductDtos>(jsonData);

            var cleint2=_httpClientFactory.CreateClient();
            var responeseMessage2=await cleint2.GetAsync("http://localhost:5001/api/ProductDetails/GetProductDetailByProductId?id="+id);
            var jsonData2=await responeseMessage2.Content.ReadAsStringAsync();
            var values2=JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData2);

        

            ViewBag.title1=values.title.ToString();
            ViewBag.price=values.price;
            ViewBag.city=values.city;
            ViewBag.district=values.district;
            ViewBag.address=values.address;
            ViewBag.description=values.description;
            ViewBag.SlugUrl=values.SlugUrl;
            ViewBag.type=values.type;
            ViewBag.advertisementDate2=values.advertisementDate;
            DateTime date1 = DateTime.Now;
            DateTime date2 = values.advertisementDate;
            TimeSpan timeSpan =date1-date2;
            int month=timeSpan.Days;
            ViewBag.advertisementDate=month/30;

            ViewBag.bathCount=values2.bathCount;
            
            ViewBag.bedRoomCount=values2.bedRoomCount;
            ViewBag.productSize=values2.productSize;
            ViewBag.roomCount=values2.roomCount;
            ViewBag.buildYear=values2.buildYear;
            ViewBag.garageSize=values2.garageSize;
            ViewBag.location=values2.location;
            ViewBag.productDetailId=values2.productDetailId;
            ViewBag.videoUrl=values2.videoUrl;


            string slugFromTitle = CreateSlug(values.title);
            ViewBag.slugUrl = slugFromTitle;

            
            return View();
        }
        private string CreateSlug(string title)
        {
            title = title.ToLowerInvariant();
            title = title.Replace(" ", "-");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]", "");
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s+", " ").Trim();
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-");

            return title;
        }
    }
}