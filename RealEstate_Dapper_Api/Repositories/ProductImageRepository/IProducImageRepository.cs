using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public interface IProducImageRepository
    {
       Task<List<GetProductImageByProductIdDto>> GetProductImageByProductId(int id);

    }
}