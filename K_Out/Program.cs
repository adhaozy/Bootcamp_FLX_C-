// Value type
//out
//Variable must be assigned before method end
class Program
{
    static void Main()
    {
        int a;
        AddTwo(out a);
        Console.WriteLine(a);
    }
    static void AddTwo(out int x)
    {
        x = 2;
        x = x + 2;
    }
}