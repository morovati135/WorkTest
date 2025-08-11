using Domain.Models.Products;
using Domain.Models.Users;

namespace Application.Repositories;

public interface IUserRepository
{
    Task<User?> GetById(int id);
    Task<IReadOnlyList<User>> GetAll();
    Task<IReadOnlyList<Product>> GetProductsByUserId(int userId);
    Task Add(User user);
    Task Update(User user);
    Task Delete(User user);
}