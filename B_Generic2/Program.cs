using Dumper;
public class Program
{
   
    public static void Main()
    {
        CustomerCollection<int> custom = new CustomerCollection<int>(20);
        custom.Add(0, 1);
        custom.Add(1, 3);
        // custom.Add(2, "Hello");
        int result = custom.GetValue(1);
        Console.WriteLine(result);
        "COba".Dump();

            //CustomerCollection<string> custom2 = new(2);
            //custom.Add(0, "a");
    }
    
}

class CustomerCollection<T>
{
    T[] myArray;
    public CustomerCollection(int arraySize)
    {
        myArray = new T[arraySize];
    }
    public bool Add(int index, T x)
    {
        myArray[index] =x;
        return true;
    }
    public T GetValue(int index)
    {
        return myArray[index];
    }
}