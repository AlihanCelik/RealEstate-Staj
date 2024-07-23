using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList(){
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
                await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
                return Ok("BottomGrid Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
             await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("BottomGrid Başarılı Bir şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto){
            await _bottomGridRepository.UpdateBottomGrid(updateBottomGridDto);
            return Ok("BottomGrid Başarıyla Güncellendi"); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBottomGrid(int id){
            var value=await _bottomGridRepository.GetBottomGrid(id);
            return Ok(value);
            
        }

    

    }
}