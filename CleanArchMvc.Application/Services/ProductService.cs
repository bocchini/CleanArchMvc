using AutoMapper;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Application.Interfaces;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        this._mapper = mapper;
        this._repository = repository ?? throw new ArgumentException(nameof(IProductRepository));
    }

    public async Task Add(ProductDto product)
    {
        await _repository.CreateAsync(_mapper.Map<Product>(product));
    }

    public async Task Delete(int id)
    {
        var product = _repository.GetProductsByIdAsync(id).Result;
        await _repository.RemoveAsync(product);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        return _mapper.Map<ProductDto>(await _repository.GetProductsByIdAsync(id));
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        return _mapper.Map<IEnumerable<ProductDto>>(await _repository.GetProductsAsync());
    }

    public async Task Update(ProductDto product)
    {
        await _repository.UpdateAsync(_mapper.Map<Product>(product));
    }
}
