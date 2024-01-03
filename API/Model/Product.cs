using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace API.Model;

public class Product
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    [ValidateNever]
    public Category Category { get; set; }
}