using Domain.Models.Products;

namespace Application.Repositories;

public interface IProductRepository
{
    Task<Product?> GetById(int id);
    Task<IReadOnlyList<Product>> GetAll();
    Task Add(Product product);
    Task Update(Product product);
    Task Delete(Product product);  
}