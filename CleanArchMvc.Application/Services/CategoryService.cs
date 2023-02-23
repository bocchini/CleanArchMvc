using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;

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
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return categoriesDto;        
    }

    public async Task<CategoryDto> GetById(int? id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task Remove(int? id)
    {
        throw new NotImplementedException();
    }

    public async Task Update(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }
}
