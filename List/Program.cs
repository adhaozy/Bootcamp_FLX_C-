
class Program
{
    static void Main()
    {
        List<int> myInt = new();
        myInt.Add(3);
        myInt.Add(4);
        myInt.Add(5);

        int result = myInt[0];
        // Console.WriteLine(result);

        List<int> myInt2 = new() {1,2,3,4,5};
        myInt2.Add(6);
        Console.WriteLine(myInt2[5]);

        List<Player> players = new()
        {
            new Player(1, "Markenji"),
            new Player(2, "Markenji"),
            new Player(3, "Markenji")
        };

        Console.WriteLine($"{players[1].Id}, {players[1].Name}");
        Console.WriteLine(players[0]);
    }
}

class Player{
    public int Id{get;}
    public string Name{get;}
    public Player(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public override string ToString()
    {
        return $"{Id}, {Name}";
    }
}