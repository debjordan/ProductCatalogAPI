using ProductCatalog.Core.Entities;

namespace ProductCatalog.Core.Repositories;

public interface ICategoryRepository
{
    Task AddAsync(Category category);
    Task<Category> GetByAssync(int id);
    Task<IEnumerable<Category>> GetAllAsync();
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
}