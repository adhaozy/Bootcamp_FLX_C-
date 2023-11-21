// Multicast Delegate
public delegate void MyDelegate(string a);
class Program
{
    static void Main()
   {
        MyDelegate hello;
        MyDelegate hai;
        Information info = new();
        
        hello = info.Displayer;
        hai = info.Markenji;

        hello.Invoke("Hello");
        hai.Invoke("Hai");
   }

}

class Information
{
    public void Displayer(string notif)
    {
        Console.WriteLine("Displayer");
    }
    public void Markenji(string notif)
    {
        Console.WriteLine("Markenji");
    }
}