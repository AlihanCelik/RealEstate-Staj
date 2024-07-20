using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface IAppUserRepository
    {
        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}