using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepositoy : IProductRepository
{
    private readonly ApplicationDbContext _productRepository;

    public ProductRepositoy(ApplicationDbContext productRepository)
    {
        this._productRepository = productRepository;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _productRepository.Add(product);
        await _productRepository.SaveChangesAsync();
        return product;
    }

    public async Task<Product> GetProductCategoryAsync(int id) => await _productRepository.Products
            .Include(c => c.Category)
            .SingleOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Product>> GetProductsAsync() => await _productRepository.Products.ToListAsync();

    public async Task<Product> GetProductsByIdAsync(int id) => await _productRepository.Products.FindAsync(id);

    public async Task<Product> RemoveAsync(Product product)
    {
        _productRepository.Remove(product);
        await _productRepository.SaveChangesAsync();
        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _productRepository.Update(product);
        await _productRepository.SaveChangesAsync();
        return product;
    }
}
