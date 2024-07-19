using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProducImageRepository _productRepository;

        public ProductImageController(IProducImageRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet("GetProductImageByProductId")]
        public async Task<IActionResult> GetProductImageByProductId(int id)
        {
            var values = await _productRepository.GetProductImageByProductId(id);
            return Ok(values);
        }

    }
}