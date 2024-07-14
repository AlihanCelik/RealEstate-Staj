using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }
        public async void CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            string query ="insert into Testimonial (NameSurname,Title,Comment,Status) values (@nameSurname ,@title,@comment,@status)";
            var parameters =new DynamicParameters();
            parameters.Add("@nameSurname",createTestimonialDto.NameSurname);
            parameters.Add("@title",createTestimonialDto.Title);
            parameters.Add("@comment",createTestimonialDto.Comment);
            parameters.Add("@status",true);

            using(var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async void DeleteTestimonial(int id)
        {
            string query="Delete From Testimonial Where TestimonialID=@testimonialID";
            var parameters =new DynamicParameters();
            parameters.Add("@testimonialID",id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResulTestimonialDto>> GetAllTestimonialAsync()
        {
            string query="Select * From Testimonial";
            using (var connection=_context.CreateConnection()){
                var values =await connection.QueryAsync<ResulTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDTestimonialDto> GetTestimonial(int id)
        {
            string query="Select * From Testimonial Where TestimonialID=@testimonialID";
            var parameters=new DynamicParameters();
            parameters.Add("@testimonialID",id);
            using(var connection = _context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIDTestimonialDto>(query,parameters);
                return values;
            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            string query="Update Testimonial Set NameSurname=@nameSurname,Title=@title,Comment = @comment , Status=@status where TestimonialID=@testimonialID";
            var parameters =new DynamicParameters();
            parameters.Add("@nameSurname",updateTestimonialDto.NameSurname);
            parameters.Add("@title", updateTestimonialDto.Title);
            parameters.Add("@comment",updateTestimonialDto.Comment);
            parameters.Add("@testimonialID",updateTestimonialDto.TestimonialID);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }
    }
}