using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQL_1;

public class Product
{
    public int ProductId {get; set;}
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;
    [Column(TypeName = "money")]
    public int UnitPrice {get; set;}
    [ForeignKey("Category")]
    public int CategoryId {get; set;}
}