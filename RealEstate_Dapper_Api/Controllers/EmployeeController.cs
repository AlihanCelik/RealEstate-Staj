using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository EmployeeRepository)
        {
            _employeeRepository = EmployeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeList(){
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
                await _employeeRepository.CreateEmployee(createEmployeeDto);
                return Ok("Kategori Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
            return Ok("Kategori Başarılı Bir şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto){
            await _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Kategori Başarıyla Güncellendi"); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id){
            var value=await _employeeRepository.GetEmployee(id);
            return Ok(value);
            
        }

    

    }
}