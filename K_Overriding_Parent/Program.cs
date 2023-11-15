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
    
     public virtual void MakeSound()
    {
        "Animal MakeSound".Dump();
    }
    
}

class Dog : Animal
{
    public virtual void MakeSound()
    {
        "guk guk".Dump();
    }
}

class Cat : Animal
{
    public override void MakeSound()
    {
        "meow meow".Dump();
    }
}

class Bird : Animal
{
    public override void MakeSound()
    {
        "cik cik".Dump();
    }
}

class Ant : Animal
{
    

}