using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList(){
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
                await _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetailDto);
                return Ok("WhoWeAreDetail Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            await _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("WhoWeAreDtail Başarılı Bir şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetail){
            await _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetail);
            return Ok("WhoWeAreDetail Başarıyla Güncellendi"); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id){
            var value=await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
            
        }
    }
}