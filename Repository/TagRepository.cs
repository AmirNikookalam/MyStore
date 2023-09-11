using Dapper;
using Shop.Data;
using Shop.Models;
using System.Data;

namespace Shop.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly IShopContext _context;
        public TagRepository(IShopContext context)
        {
            _context = context;
        }

        public async Task Create(Tag _Tag)
        {
            var query = "INSERT INTO " + typeof(Tag).Name + " (Name, Product) VALUES (@Name, @Product)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", _Tag.Name, DbType.String);
            parameters.Add("Product", _Tag.Products, DbType.String);

            using var connection = _context.Connection();

            await connection.ExecuteAsync(query, parameters);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> GetTagAsync()
        {
            var query = "select * from Tag";

            using (var connection = _context.Connection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Tag>(query);
                return result;
            }
        }

        public Task Update(Tag _Tag)
        {
            throw new NotImplementedException();
        }
    }
}
