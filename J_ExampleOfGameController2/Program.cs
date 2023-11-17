//GameController


//Library Consumer
class Program 
{
	static void Main()
	{
		// * User defined Tiles configuration
		Tile[] tiles = new Tile[]{
			new Start(),
			new City(100, "Jakarta", "Kota Jakarta"),
			new City(23, "Semarang", "Kota Jakarta"),
			new City(11, "Surabaya", "Kota Jakarta"),
			new Company(),
			new Jail()
		};
		GameController game = new GameController(tiles);
	}
}



//Library
class GameController 
{
	Tile[] tiles;
	// * It will make the Tiles configuration 
	// * depend on user concern
	public GameController(Tile[] tiles) {
		this.tiles = tiles;
	}
	// ! (Warning) It will make the Tiles configuration fixed
	public GameController()
	{
		tiles = new Tile[]{
			//new City(),
			new Company(),
			new Jail()
		};
	}
	public void CallTileAction(int index) {
		string type = tiles[index].type;
		if(type == "City") 
		{
			((City)tiles[index]).Build();
		}
		if (type == "Company")
		{
			((Company)tiles[index]).Buy();
		}
		if(type == "Jail")
		{
			((Jail)tiles[index]).Roll();
		}
	}
}


public abstract class Tile 
{
	public readonly string type;
	public readonly string description;
	public readonly string name;
	public Tile(string type, string name, string description) 
	{
		this.type = type;
		this.name = name;
		this.description = description;
	}
	public Tile() 
	{
		
	}
}
class City : Tile 
{
	private int _price;
	public City(int price, string name, string description) : base("city", name, description)
	{
		_price = price;
	}
	public int GetPrice()
	{
		return _price;
	}
	public void Build() 
	{
		//Buy
	}
}
class Company : Tile {
	public void Buy() 
	{
		//Buy
	}
 }
class Jail : Tile {
	public void Roll() 
	{
		//Buy
	}
 }
 public class Start : Tile
{
	
}