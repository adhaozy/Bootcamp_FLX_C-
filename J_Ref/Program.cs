// Value Type
// Ref
// Variable must be assigned before passed
class Program
{
    static void Main()
    {
        int a =3;
        AddTwo(ref a);
        Console.WriteLine(a);
    }
    static void AddTwo(ref int x)
    {
        x = x + 2;
    }
}