using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
         private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public async void CreateContact(CreateContactDto createContactDto)
        {
            string query ="insert into Contact (Name,Subject,Email,Message,SendDate) values (@name ,@subject,@email,@message,@sendDate)";
            var parameters =new DynamicParameters();
            parameters.Add("@name",createContactDto.Name);
            parameters.Add("@subject",createContactDto.Subject);
            parameters.Add("@email",createContactDto.Email);
            parameters.Add("@message",createContactDto.Message);
            parameters.Add("@sendDate",createContactDto.SendDate);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async void DeleteContact(int id)
        {
            string query="Delete From Contact Where ContactID=@contactID";
            var parameters =new DynamicParameters();
            parameters.Add("@contactID",id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query="Select * From Contact";
            using (var connection=_context.CreateConnection()){
                var values =await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContact(int id)
        {
            string query="Select * From Contact Where ContactID=@contactID";
            var parameters=new DynamicParameters();
            parameters.Add("@contactID",id);
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIDContactDto>(query,parameters);
                return values;
            }
        }

        public async Task<List<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query="Select Top(4) * From Contact order by ContactID Desc";
            using (var connection=_context.CreateConnection()){
                var values =await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }
    }
}