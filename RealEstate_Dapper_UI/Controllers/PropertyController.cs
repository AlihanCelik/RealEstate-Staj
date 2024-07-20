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
        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id =1;
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
            ViewBag.productDetailId=values2.productDetailId;


            
            return View();
        }
    }
}