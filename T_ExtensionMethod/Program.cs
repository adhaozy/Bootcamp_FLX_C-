// Extensions Method
// Support for OpenClose Principle in SOLID
void Main()
{
    
}

public static class IniExtension{
    public static int Tambah(this int a, int b){
        return a + b;
    }
    public static void Cetak(this object a)
    {
        Console.WriteLine(a);
    }
}