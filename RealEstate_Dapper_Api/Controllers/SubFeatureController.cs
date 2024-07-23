using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubFeatureController:ControllerBase
    {
        private readonly ISubFeatureRepository _SubFeatureRepository;

        public SubFeatureController(ISubFeatureRepository SubFeatureRepository)
        {
            _SubFeatureRepository = SubFeatureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubFeatureAsync(){
            var values=await _SubFeatureRepository.GetAllSubFeatureAsync();
            return Ok(values);
        }
    }
}