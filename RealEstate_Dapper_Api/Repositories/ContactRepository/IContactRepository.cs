using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContact(CreateContactDto createContactDto);
        Task DeleteContact(int id);
        Task<GetByIDContactDto> GetContact(int id);
        Task<List<Last4ContactResultDto>> GetLast4ContactAsync();
    }
}