using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
   // private readonly IProductRepository _repository;
    private readonly IMediator _mediator;    

    public ProductService(IMediator mediator, IMapper mapper)
    {
        this._mapper = mapper;
        _mediator = mediator;
        //_repository = repository ?? throw new ArgumentException(nameof(IProductRepository));
    }

    public async Task Add(ProductDto product)
    {
        //await _repository.CreateAsync(_mapper.Map<Product>(product));
        var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
        await _mediator.Send(productCreateCommand);
    }

    public async Task Delete(int id)
    {
        //var product = _repository.GetProductsByIdAsync(id).Result;
        //await _repository.RemoveAsync(product);
        var productRemoveCommand = new ProductRemoveCommand(id);
        await _mediator.Send(productRemoveCommand);
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        var productByIdQuery = new GetProductByIdQuery(id);
        if (productByIdQuery != null) throw new Exception($"Entity could not be loaded");
        var result = await _mediator.Send(productByIdQuery);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        var productQuery = new GetProductsQuery();
        if (productQuery == null) throw new Exception($"Entity could be loaded");

        return _mapper.Map<IEnumerable<ProductDto>>(await _mediator.Send(productQuery));
    }

    public async Task Update(ProductDto product)
    {
        //await _repository.UpdateAsync(_mapper.Map<Product>(product));
        var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
        await _mediator.Send(productUpdateCommand);
    }
}
