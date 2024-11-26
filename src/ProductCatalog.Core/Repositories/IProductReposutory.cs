using System.Collections;
using System.Diagnostics;
using ProductCatalog.Core.Entities;

namespace ProductCatalog.Core.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    Task<Product> GetByAsync(int id);
    Task<IEnumerable<Product>> GetAllAsync();
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);   
    
}