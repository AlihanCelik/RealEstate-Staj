using RealEstate_Dapper_Api.Hubs;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepositpry;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper_Api.Repositories.MessageRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddTransient<Context>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IWhoWeAreDetailRepository,WhoWeAreDetailRepository>();
builder.Services.AddTransient<IServiceRepository,ServiceRepository>();
builder.Services.AddTransient<IBottomGridRepository,BottomGridRepository>();
builder.Services.AddTransient<IPopularLocationRepository,PopularLocationRepository>();
builder.Services.AddTransient<ITestimonialRepository,TestimonialRepository>();
builder.Services.AddTransient<IEmployeeRepository,EmployeeRepository>();
builder.Services.AddTransient<IStatisticsRepository,StatisticsRepository>();
builder.Services.AddTransient<IContactRepository,ContactRepository>();
builder.Services.AddTransient<IToDoListRepository,ToDoListRepository>();
builder.Services.AddTransient<IStatisticRepository,StatisticRepository>();
builder.Services.AddTransient<IChartRepository,ChartRepository>();
builder.Services.AddTransient<ILast5ProductsRepository,Last5ProductsRepository>();
builder.Services.AddTransient<IMessageRepository,MessageRepository>();
builder.Services.AddTransient<IProducImageRepository,ProductImageRepository>();
builder.Services.AddTransient<IAppUserRepository,AppUserRepository>();
builder.Services.AddTransient<IPropertyAmenityRepository,PropertyAmenityRepository>();

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("CorsPolicy",builder =>
    {
        builder.AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host)=>true)
                .AllowCredentials();
    });
});
builder.Services.AddHttpClient();
builder.Services.AddSignalR();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.MapControllers();
app.MapHub<SignalRHub>("/signalrhub");

app.Run();

