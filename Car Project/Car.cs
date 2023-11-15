using CarComponent;
namespace Car_Project;

public class Car // blueprint
{
	public Engine engine;
	public string myString;
	public int x;
	public Tire tire;
	public Wiper wiper;
	public Door door;
	public Exhaust exhaust;
	
	public Car(Engine en, Tire tr, Wiper wp, Door door, Exhaust ex) // method constructor
	{
		engine = en;
		tire = tr;
		wiper = wp;
		this.door = door;
		exhaust = ex;
	}
	public Car() // constructor
	{
		
	}
	
	public void EngineRun() // method
	{
		engine.EngineTest(); // test engine
	}
	public string EngineBrandCheck() 
	{
		return engine.brand;
	}
}