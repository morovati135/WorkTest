using Domain.Models.Users;

namespace Domain.Models.Products;

public class Product
{
    public int ProductId {get; set;}
    public string Name {get; set;}
    public decimal Price {get; set;}
    
    public int UserId {get; set;}
    public User User {get; set;}
}