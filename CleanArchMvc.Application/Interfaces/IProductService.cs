using CleanArchMvc.Application.Dtos;

namespace CleanArchMvc.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto> GetProductByIdAsync(int id);
    Task Add(ProductDto product);
    Task Update(ProductDto product);
    Task Delete(int id);
}
