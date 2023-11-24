using FooBar1;
using System.Net.Security;

// Main program 

class Program
{
    public static void Main()
    {
        FooBar b = new FooBar(1);
        List<object> mixedList = new List<object>
        {
        b
        };
        Console.WriteLine(b);
    }
}