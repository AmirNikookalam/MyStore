using System.Data;

namespace Shop.Data
{
    public interface IShopContext
    {
        IDbConnection Connection();
    }
}
