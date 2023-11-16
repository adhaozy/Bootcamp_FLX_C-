//Abstraction
//Abstract class

class Program{
    static void Main(){
        RumahMewah rm = new RumahMewah();
        RumahBiasa rb = new RumahBiasa();
        RumahSederhana rs = new RumahSederhana();

        Rumah rumah = rb;
        rumah.BukaPintu();
    }
}

abstract class Rumah
{
	public readonly int i;
	public void BukaJendela() {
		"Buka jendela".Dump();
	}
	public virtual void BukaGarasi() {
		"Keatas".Dump();
	}
	public abstract void BukaPintu();
}

class RumahMewah : Rumah
{
    public override void BukaPintu()
    {
        "Keastass".Dump();
    }
}

class RumahBiasa : Rumah
{
    public override void BukaPintu()
    {
        "Kedepan".Dump();
    }
}

class RumahSederhana : Rumah
{
    public override void BukaPintu()
    {
        "Gorden".Dump();
    }
}

public static class IniExtension
{
	public static void Dump(this object x) 
	{
		Console.WriteLine(x.ToString());
	}
}