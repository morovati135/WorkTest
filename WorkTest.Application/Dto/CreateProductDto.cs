namespace Application.Dto;

public class CreateProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int UserId { get; set; }
}