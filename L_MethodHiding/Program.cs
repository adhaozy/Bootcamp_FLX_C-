// Overriding (Virtual - Overriding)
class Program
{
    static void Main()
    {
        Animal animal = new();
        animal.MakeSound();
    }
}

class Animal
{
    
     public void MakeSound()
    {
        "Animal MakeSound".Dump();
    }
    
}

class Dog : Animal
{
    public new void MakeSound()
    {
        "guk guk".Dump();
    }
}

class Cat : Animal
{
    public void MakeSound()
    {
        "meow meow".Dump();
    }
}

class Bird : Animal
{
    public void MakeSound()
    {
        "cik cik".Dump();
    }
}

class Ant : Animal
{
    

}