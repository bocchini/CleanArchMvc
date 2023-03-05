using MediatR;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Application.Products.Queries;

namespace CleanArchMvc.Application.Products.Handlers;

public class GetProductByIdHandler:IRequestHandler<GetProductByIdQuery, Product>
{
    public readonly IProductRepository _productRepository;

    public GetProductByIdHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetProductsByIdAsync(request.Id);
    }
}
