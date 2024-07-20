using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepository
{
    public class AppUserRepository : IAppUserRepository
    {
         private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetAppUserByProductId> GetAppUser(int id)
        {
           string query="Select * From AppUser Where UserId=@userId";
            var parameters=new DynamicParameters();
            parameters.Add("@userId",id);
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetAppUserByProductId>(query,parameters);
                return values;
            }
        }
    }
}