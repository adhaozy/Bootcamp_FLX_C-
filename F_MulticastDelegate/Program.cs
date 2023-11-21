// Multicast Delegate
public delegate void MyDelegate();
class Program
{
    static void Main()
    {
        MyDelegate mydel = Display; // masukaan method kedalam delegate
        mydel += Markenji; // menambahkan method yang ingin di panggil
        mydel.Invoke();

        mydel -= Markenji; // cara pilih method yang ingin dihilangkan dari delegate
        mydel();
    }
    static void Display()
    {
        Console.WriteLine("Hello World!");
    }
    static void Markenji()
    {
        Console.WriteLine("Mar");
    }
}