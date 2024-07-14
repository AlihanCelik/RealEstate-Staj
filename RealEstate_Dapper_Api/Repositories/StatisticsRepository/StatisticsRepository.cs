using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.StatisticsRepository;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly Context _context;

        public StatisticsRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query="Select Count(*) From Category Where CategoryStatus=1";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query="Select Count(*) From Employee Where Status=1";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query="Select Count(*) From Product Where Title like '%Daire%'";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query="Select Avg(Price) From Product Where Type = N'Satılık'";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<decimal?>(query);
                return values ?? 0;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query="Select Avg(Price) From Product Where Type = N'Kiralık'";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<decimal?>(query);
                
                return values ?? 0;
            }
        }

        public int AverageRoomCount()
        {
            string query="Select Avg(RoomCount) From ProductDetails";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int?>(query);
                
                return values ?? 0;
            }
        }

        public int CategoryCount()
        {
            string query="Select Count(*) From Category";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<int?>(query);
                
                return values ?? 0;
            }
        }

        public string CategoryNameByMaxProductByRent()
        {
            string query = "Select top(1) CategoryName,Count(*) From Product inner join Category On Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
            using(var connection = _context.CreateConnection())
            {
                var values= connection.QueryFirstOrDefault<string>(query);
                
                return values ;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = "Select Top(1) City,Count(*) as 'product_count' From Product Group By City order by product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()
        {
            string query = "Select Count(Distinct(City)) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "Select Name,Count(*) 'product_count' From Product Inner Join Employee On Product.EmployeeID=Employee.EmployeeID Group By Name Order By product_count Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "Select Top(1) Price From Product Order By ProductID Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Desc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select Top(1) BuildYear From ProductDetails Order By BuildYear Asc";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select Count(*) From Category Where CategoryStatus=0";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select Count(*) From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}