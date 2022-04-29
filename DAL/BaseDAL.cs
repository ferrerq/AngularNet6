using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class BaseDAL
    {
        protected string DB1ConnectionString = "";
        protected string DB2ConnectionString = "";
        protected string ExcelConnectionString = "";
        public BaseDAL(IConfiguration configuration)
        {
            DB1ConnectionString = configuration.GetConnectionString("DB1");
            DB2ConnectionString = configuration.GetConnectionString("DB2");
            ExcelConnectionString = configuration.GetConnectionString("Excel");
        }
    }
}