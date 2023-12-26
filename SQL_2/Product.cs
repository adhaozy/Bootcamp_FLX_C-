namespace EFCoreTutorial;

public class Product
{
	public int ProductId { get; set; }
	public string ProductName { get; set; }	
	public int CategoryId { get; set; }
	public int QuantityPerUnit { get; set; }
	public int Cost { get; set; }
	public Category Category { get; set; }
}
