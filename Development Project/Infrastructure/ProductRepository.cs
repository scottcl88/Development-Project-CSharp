using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public interface IProductRepository { 
    Task<ProductEntity> GetProductByIdAsync(int id);
    Task<List<ProductEntity>> GetProductsAsync();
    Task<ProductEntity> CreateProductAsync(ProductEntity product);
    Task<ProductEntity> UpdateProductAsync(ProductEntity product);
}
public class ProductRepository: IProductRepository {
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProductEntity> GetProductByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Metadata)
            .Include(p => p.Categories)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<List<ProductEntity>> GetProductsAsync()
    {
        return await _context.Products
            .Include(p => p.Metadata)
            .Include(p => p.Categories)
            .ToListAsync();
    }
    public async Task<ProductEntity> CreateProductAsync(ProductEntity product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }
    public async Task<ProductEntity> UpdateProductAsync(ProductEntity product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
        return product;
    }
}