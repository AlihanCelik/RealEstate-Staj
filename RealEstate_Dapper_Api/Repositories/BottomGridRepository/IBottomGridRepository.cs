using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetByIDBottomGridDto> GetBottomGrid(int id);
    }
}