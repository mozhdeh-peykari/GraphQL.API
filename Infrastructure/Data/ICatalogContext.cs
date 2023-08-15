using Core.Entities;
using MongoDB.Driver;

namespace Infrastructure.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Category> Categories { get; }
        IMongoCollection<Product> Products { get; }
    }
}
