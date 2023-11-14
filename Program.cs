using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        Cat pokariswet = new Cat();
        pokariswet.colour = "Red";
        string result = pokariswet.colour;
        Console.WriteLine(result);

        Cat jiji = new Cat();
        jiji.colour = "Green";
        string result1 = jiji.colour;
        Console.WriteLine(result1);

        Cat coki = new Cat();
        coki.colour = "Blue";
        string result2 = coki.colour;
        Console.WriteLine(result2);

        Cat tompel = new Cat();
        tompel.colour = "Pink";
        string result3 = tompel.colour;
        Console.WriteLine(result3);
    }
}

class Cat
{
    public string colour;
    public int Age;
    public bool isMale;
    public float weight;

    public void eat()
    {
        Console.WriteLine("MAKAN IKAN");
    }
    public void sleep()
    {
        Console.WriteLine("Tidur siang");
    }
    public void chaos()
    {
        Console.WriteLine("Ngamuk minta makan");
    }
    public void meow()
    {
        Console.WriteLine("meow minta di lus lus");
    }
}