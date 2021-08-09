using Microsoft.Extensions.Configuration;
namespace CareerCloud.EntityFrameworkDataAccess
{
    public  class DBConnection
    {
         string _connectionstring;
        public DBConnection()
        {
        }
        public string connection()
        {
            var config = new ConfigurationBuilder();
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
           return  _connectionstring = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
    }
}
