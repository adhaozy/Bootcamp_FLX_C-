// Single Delegate
public delegate void MyDelegate();
class Program 
{
    static void Main()
    {
        MyDelegate mydel = Display;
        mydel.Invoke();
        mydel();
    }
    static void Display()
    {
        Console.WriteLine("Hello World!");
    }
    static void Markenji()
    {
        Console.WriteLine("OHNO");
    }
}