using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepositpry;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServicesController(IServiceRepository categoryRepository)
        {
            _serviceRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ServiceList(){
            var values = await _serviceRepository.GetAllServiceAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateService(CreateServiceDto createServiceDto)
        {
                _serviceRepository.CreateService(createServiceDto);
                return Ok("Service Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Service Başarılı Bir şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto){
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Service Başarıyla Güncellendi"); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id){
            var value=await _serviceRepository.GetService(id);
            return Ok(value);
            
        }

    

    }
}