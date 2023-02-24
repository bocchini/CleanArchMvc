using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Application.Interfaces;

namespace CleanArchMvc.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task Add(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.CreateAsync(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return categoriesDto;        
    }

    public async Task<CategoryDto> GetById(int? id)
    {
        var category = _categoryRepository.GetByIdAsync(id).Result;
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task Remove(int? id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        await _categoryRepository.RemoveAsync(category);        
    }

    public async Task Update(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _categoryRepository.UpdateAsync(category);
    }
}
