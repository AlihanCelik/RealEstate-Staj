using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _ContactRepository;

        public ContactController(IContactRepository ContactRepository)
        {
            _ContactRepository = ContactRepository;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList(){
            var values = await _ContactRepository.GetAllContactAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult>CreateContact(CreateContactDto createContactDto)
        {
                await _ContactRepository.CreateContact(createContactDto);
                return Ok("Contact Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _ContactRepository.DeleteContact(id);
            return Ok("Contact Başarılı Bir şekilde Silindi.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id){
            var value=await _ContactRepository.GetContact(id);
            return Ok(value);
            
        }

        [HttpGet("GetLast4ContactAsync")]
        public async Task<IActionResult> GetLast5ProductAsync(){
            var values = await _ContactRepository.GetLast4ContactAsync();
            return Ok(values);
        }


    

    }
}