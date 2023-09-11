using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Shop.Data
{
    public class ShopContext : IShopContext
    {
        private readonly IConfiguration _iConfiguration;
        private readonly string _connString;
        public ShopContext(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;
            _connString = _iConfiguration.GetConnectionString("connMSSQL");
        }
        public IDbConnection Connection() => new SqlConnection(_connString);

    }
}
