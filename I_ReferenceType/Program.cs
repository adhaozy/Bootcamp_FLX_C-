// Reference Type
class Program
{
    static void Main()
    {
        MyInt myInt = new MyInt();
        myInt.value = 10;
        AddTwo(myInt);
        Console.WriteLine(myInt.value);
    }
    static void AddTwo(MyInt a)
    {
        a.value = a.value + 2;
    }
}

class MyInt
{
    public int value;
}