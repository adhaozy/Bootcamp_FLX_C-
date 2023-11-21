// Multicast Delegate
public delegate void MyDelegate();
class Program{
    static void Main()
    {
        MyDelegate mydel; // membuat delegate
        Information info = new(); // membuat object info

        mydel = info.Display; // Object diberikan sebelum pemanggilan method yang akan di hubungkan dengan delelgate
        mydel += info.Markenji;

        mydel.Invoke();
    }
}

class Information
{
    public void Display()
    {
        Console.WriteLine("Information");
    }
    public void Markenji()
    {
        Console.WriteLine("Markenji");
    }
}