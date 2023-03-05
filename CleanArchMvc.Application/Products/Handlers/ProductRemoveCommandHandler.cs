using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Products.Handlers;

public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
{
    public readonly IProductRepository _productRepository

    public ProductRemoveCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductsByIdAsync(request.Id);
        if (product == null) throw new ApplicationException("Entity could not be found");

        var result = await _productRepository.RemoveAsync(product); ;
        return result;
    }
}
