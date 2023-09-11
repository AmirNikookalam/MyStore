using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System.Data;
using static Dapper.SqlMapper;

namespace Shop.Repository
{
    public class ShopRepository : IShopRepository
    {
        private readonly IShopContext _context;
        public ShopRepository(IShopContext context)
        {
            _context = context;
        }

        public async Task Create(Product _Product)
        {
            var query = "INSERT INTO " + typeof(Product).Name + " (Name, Price,Date,TagId,Tag) VALUES (@Name, @Price,@Date,@TagId,@Tag)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", _Product.Name, DbType.String);
            parameters.Add("Price", _Product.Price, DbType.String);
            parameters.Add("Date", _Product.Date, DbType.String);
            parameters.Add("TagId", _Product.TagId, DbType.String);
            parameters.Add("Tag", _Product.Tag, DbType.String);

            using var connection = _context.Connection();

            await connection.ExecuteAsync(query, parameters);
        }

        public async Task Delete(int id)
        {
            var query = "DELETE FROM " + typeof(Product).Name + " WHERE Id = @Id";
            using (var connection = _context.Connection())
            {
                await connection.ExecuteAsync(query, new { id });
            }
        }

        public async Task<Product> GetProductsAsync()
        {
            var query = "select * from Product";

            using (var connection = _context.Connection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Product>(query);
                return result;
            }
        }

    }
}
