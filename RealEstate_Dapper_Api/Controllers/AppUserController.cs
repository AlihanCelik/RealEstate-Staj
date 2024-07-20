using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController:ControllerBase
    {
        private readonly IAppUserRepository _AppUserRepository;

        public AppUserController(IAppUserRepository AppUserRepository)
        {
            _AppUserRepository = AppUserRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAppUser(int id){
            var values=await _AppUserRepository.GetAppUser(id);
            return Ok(values);
        }
    }
}