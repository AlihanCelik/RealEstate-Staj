using Microsoft.Identity.Client;

namespace RealEstate_Dapper_Api.Dtos.MessageDtos
{
    public class ResutInBoxMessageDto
    {
        public int MessageId { get; set; }
        public string Name {get; set;}
        public string Subject {get; set;}
        public string Detail {get; set;}
        public DateTime SendDate {get; set;}
        public bool IsRead {get; set;}
        public string UserImageUrl {get; set;}
    }
}