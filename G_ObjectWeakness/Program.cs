// Object weakness
// No type check
using System.Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        // Fixed Size
        // Not safety
        object[] myArray = { 1, "true", true, 3.0f, 5 };

        // Dynamic Size
        // Not safety
        ArrayList myArrayList = new ArrayList();
        myArrayList.Add(1);
        myArrayList.Add(true);
        myArrayList.Add("true");

        Type type = myArray[0].GetType();
        Type coba = myArray[1].GetType();
        Console.WriteLine(coba.ToString());

        
    }
}