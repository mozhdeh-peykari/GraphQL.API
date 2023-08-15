using Core.Entities;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(string id);
    }
}
