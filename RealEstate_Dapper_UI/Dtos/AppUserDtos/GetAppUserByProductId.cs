namespace RealEstate_Dapper_UI.Dtos.AppUserDtos
{
    public class GetAppUserByProductId
    {
        public int UserId {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public string UserImageUrl {get; set;}
    }
}