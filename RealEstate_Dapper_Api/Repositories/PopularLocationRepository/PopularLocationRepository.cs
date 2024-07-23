using Dapper;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        public readonly Context _context;
        public PopularLocationRepository(Context context)
        {
            _context=context;
        }
        public async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            string query ="insert into PopularLocation (CityName,ImageUrl) values (@cityName ,@imageUrl)";
            var parameters =new DynamicParameters();
            parameters.Add("@cityName",createPopularLocationDto.CityName);
            parameters.Add("@imageUrl",createPopularLocationDto.ImageUrl);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeletePopularLocation(int id)
        {
            string query="Delete From PopularLocation Where LocationID=@locationID";
            var parameters=new DynamicParameters();
            parameters.Add("@locationID",id);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query="Select * From PopularLocation";
            using(var connection=_context.CreateConnection())
            {
                var values=await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDPopularLocationDto> GetPopularLocation(int id)
        {
            var query="Select * From PopularLocation Where LocationID=@locationID";
            var parameters=new DynamicParameters();
            parameters.Add("@locationID",id);
            using(var connection=_context.CreateConnection())
            {
                var values= await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            var query="Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl Where LocationID=@locationID";
            var parameters=new DynamicParameters();
            parameters.Add("@locationID",updatePopularLocationDto.LocationID);
            parameters.Add("@cityName",updatePopularLocationDto.CityName);
            parameters.Add("@imageUrl",updatePopularLocationDto.ImageUrl);
            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }


        }
    }
}