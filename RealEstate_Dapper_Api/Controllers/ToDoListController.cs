using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _ToDoListRepository;

        public ToDoListController(IToDoListRepository ToDoListRepository)
        {
            _ToDoListRepository = ToDoListRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ToDoListList(){
            var values = await _ToDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateToDoList(CreateToDoListDto createToDoListDto)
        {
                await _ToDoListRepository.CreateToDoList(createToDoListDto);
                return Ok("Yapılacaklar Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            await _ToDoListRepository.DeleteToDoList(id);
            return Ok("Yapılacaklar Başarılı Bir şekilde Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto){
            await _ToDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("Yapılacaklar Başarıyla Güncellendi"); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id){
            var value=await _ToDoListRepository.GetToDoList(id);
            return Ok(value);
            
        }

    

    }
}