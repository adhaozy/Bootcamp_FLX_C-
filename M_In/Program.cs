// Value Type
// In =  ReadOnly
// Variable must be assigned before passed
// But its ReadOnly 

class Program
{
    static void Main()
    {
        int a = 3;
        AddTwo(a);
        Console.WriteLine(a);
    }
    static void AddTwo(int a)
    {
        a = a + 2;
    }
}