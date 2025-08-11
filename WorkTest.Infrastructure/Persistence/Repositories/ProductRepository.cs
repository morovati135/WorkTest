using Application.Repositories;
using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;

namespace WorkTest.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly WorkTestDbContext _context;

    public ProductRepository(WorkTestDbContext context)
    {
        _context = context;
    }

    public async Task Add(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Product>> GetAll()
    {
        return await _context.Products.Include(p => p.User).ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    {
        return await _context.Products.Include(p => p.User)
            .FirstOrDefaultAsync(p => p.ProductId == id);
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }
}