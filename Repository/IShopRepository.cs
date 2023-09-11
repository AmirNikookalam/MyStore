using Shop.Models;

namespace Shop.Repository
{
    public interface IShopRepository
    {
        Task<Product> GetProductsAsync();
        Task Create(Product _Product);
        Task Delete(int id);
    }
}
