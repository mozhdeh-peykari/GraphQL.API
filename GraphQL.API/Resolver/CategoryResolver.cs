using Core.Entities;
using Core.Repositories;

namespace GraphQL.API.Resolver
{
    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver
    {
        public Task<Category> GetCategoryAsync(
          [Parent] Product product,
          [Service] ICategoryRepository categoryRepository) => categoryRepository.GetById(product.CategoryId);
    }
}
