using Application.Repositories;
using Domain.Models.Products;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace WorkTest.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WorkTestDbContext _context;

    public UserRepository(WorkTestDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<User>> GetAll()
    {
        return await _context.Users.Include(u => u.Products).ToListAsync();
    }
    
    public async Task<IReadOnlyList<Product>> GetProductsByUserId(int userId)
    {
        return await _context.Products
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.Include(u => u.Products)
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    public async Task Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
}