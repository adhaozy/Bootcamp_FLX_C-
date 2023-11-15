class Program
{
    static void Main()
    {
        ElectricEngine ee = new();
        HydroEngine hy = new();

        Car car = new Car(ee);
        car.EngineRun();
    }
}

class Car 
{
    public Engine engine;
    public void EngineRun()
    {
        engine.Start();
    }
    public Car(Engine engine)
    {
        this.engine = engine;
    }
}

class Engine
{
    public virtual void Start()
    {
        "Enginer Starting".Dump();
    }
}

class ElectricEngine : Engine
{
    public new void Start()
    {
        "ElectricEngine Starting".Dump();
    }
}

class HydroEngine
{
    public void Start()
    {
        "HydroEngine Starting".Dump();
    }
}

public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}