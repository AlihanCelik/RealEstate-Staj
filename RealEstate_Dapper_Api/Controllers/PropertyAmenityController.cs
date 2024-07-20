using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenityController:ControllerBase
    {
        private readonly IPropertyAmenityRepository _PropertyAmenityRepository;

        public PropertyAmenityController(IPropertyAmenityRepository PropertyAmenityRepository)
        {
            _PropertyAmenityRepository = PropertyAmenityRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id){
            var values=await _PropertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id);
            return Ok(values);
        }
    }
}