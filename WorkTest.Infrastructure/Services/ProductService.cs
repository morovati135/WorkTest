using Application.Dto;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Domain.Models.Products;

namespace Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDto?> GetProductById(int id)
    {
        var product = await _productRepository.GetById(id);
        return product == null ? null : _mapper.Map<ProductDto>(product);
    }

    public async Task<IReadOnlyList<ProductDto>> GetAllProducts()
    {
        var products = await _productRepository.GetAll();
        return _mapper.Map<IReadOnlyList<ProductDto>>(products);
    }

    public async Task<ProductDto> CreateProduct(CreateProductDto createProductDto)
    {
        var product = _mapper.Map<Product>(createProductDto);
        await _productRepository.Add(product);
        return _mapper.Map<ProductDto>(product);
    }

    public async Task UpdateProduct(int id, UpdateProductDto updateProductDto)
    {
        var product = await _productRepository.GetById(id);
        if (product == null) throw new Exception("Product not found");

        _mapper.Map(updateProductDto, product);
        await _productRepository.Update(product);
    }

    public async Task DeleteProduct(int id)
    {
        var product = await _productRepository.GetById(id);
        if (product == null) throw new Exception("Product not found");
        await _productRepository.Delete(product);
    }
}