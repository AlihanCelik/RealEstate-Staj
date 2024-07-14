
using RealEstate_Dapper_Api.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        Task<List<ResutInBoxMessageDto>> GetInBoxLast3MessageListByReceiver(int id);

    }
}