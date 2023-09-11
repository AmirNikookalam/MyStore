using Shop.Models;

namespace Shop.Repository
{
    public interface ITagRepository
    {
        Task<Tag> GetTagAsync();
        Task Create(Tag _Tag);
        Task Update(Tag _Tag);
        Task Delete(int id);
    }
}
