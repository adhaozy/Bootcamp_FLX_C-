using System.Data;
using System.Data.Common;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using GameControllerLib
public class Program
{
    public static void Main()
    {
        Dice dadu = new Dice();
        Console.WriteLine(dadu.GetRandomNumberPublic());

        
    }
}