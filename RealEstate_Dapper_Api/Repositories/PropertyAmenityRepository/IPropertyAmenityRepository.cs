using RealEstate_Dapper_Api.Dtos.PropertyAmentiyDtos;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}