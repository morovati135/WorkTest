using Application.Dto;

namespace Application.Services;

public interface IProductService
{
    Task<IReadOnlyList<ProductDto>> GetAllProducts();
    Task<ProductDto?> GetProductById(int id);
    Task<ProductDto> CreateProduct(CreateProductDto createProductDto);
    Task UpdateProduct(int id, UpdateProductDto updateProductDto);
    Task DeleteProduct(int id);
}