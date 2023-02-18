using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;

namespace CleanArchMvc.Infra.Data.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _categoryRepository;

    public CategoryRepository(ApplicationDbContext applicationDbContext)
    {
        this._categoryRepository = applicationDbContext;
    }
    public async Task<Category> CreateAsync(Category category)
    {
        _categoryRepository.Add(category);
        await _categoryRepository.SaveChangesAsync();
        return category;
    }

    public async Task<Category> GetByIdAsync(int id) => await _categoryRepository.Categories.FindAsync(id);


    public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _categoryRepository.Categories.ToListAsync();

    public async Task<Category> RemoveAsync(Category category)
    {
        _categoryRepository.Remove(category);
        await _categoryRepository.SaveChangesAsync();
       return category;
    }

    public async Task<Category> UpdateAsync(Category category)
    {
        _categoryRepository.Update(category);
        await _categoryRepository.SaveChangesAsync();
        return category;        
    }
}
