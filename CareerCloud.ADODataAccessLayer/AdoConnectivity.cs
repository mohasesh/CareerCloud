using Microsoft.Extensions.Configuration;
namespace CareerCloud.ADODataAccessLayer
{
    public abstract class AdoConnectivity
    {
        protected string _connectionstring;
        public AdoConnectivity()
        {
            var config = new ConfigurationBuilder();
            var path = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
             _connectionstring = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
        }
    }
}
