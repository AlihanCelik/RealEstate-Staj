
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.StatisticRepositories;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.ServiceRepositpry;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;
using RealEstate_Dapper_Api.Repositories.MessageRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories;

namespace RealEstate_Dapper_Api.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddTransient<Context>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IWhoWeAreDetailRepository, WhoWeAreDetailRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();
            services.AddTransient<IBottomGridRepository, BottomGridRepository>();
            services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
            services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            services.AddTransient<ITestimonialRepository, TestimonialRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IToDoListRepository, ToDoListRepository>();
            services.AddTransient<ILoginRepo, LoginRepo>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IChartRepository, ChartRepository>();
            services.AddTransient<ILast5ProductsRepository, Last5ProductsRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            services.AddTransient<IProducImageRepository, ProductImageRepository>();
            services.AddTransient<IAppUserRepository, AppUserRepository>();
            services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
            services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
        }
    }
}
