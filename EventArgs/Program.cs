using Internal;
// Event
class Program
{
    public static void Main()
    {
        Publisher pub = new("Yusuf");
        Subcriber sub = new();
        pub.sub += sub.GetNotif;

        pub.SendNotif();
    }

    public class Publisher{
        public readonly string Name;

        public event EventHandler subs;

        public Publisher(string name){
            Name = name;
        }
        public void SendNotif(){
            subs?.Invoke(Name, EventArgs.Empty);
        }
        public override string ToString()
        {
            return Name;
        }
    }
    
    class Subscriber
    {
        public void GetNotif(object sender, EventArgs e)
        {
            Console.WriteLine($"Subscriber got notified from {sender}");
        }
    }
}