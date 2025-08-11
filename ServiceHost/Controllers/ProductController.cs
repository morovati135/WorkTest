using Application.Dto;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("All")]
    public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAll()
    {
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("FindById/{id}")]
    public async Task<ActionResult<ProductDto>> GetById(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ProductDto>> Create(CreateProductDto createProductDto)
    {
        var product = await _productService.CreateProduct(createProductDto);
        return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(int id, UpdateProductDto updateProductDto)
    {
        try
        {
            await _productService.UpdateProduct(id, updateProductDto);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}