namespace LudoLib
{
    // Implement the IPlayer interface in the Player class
    public class Player : IPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Colors Color { get; set; }

    public List<Piece> Pieces { get; } = new List<Piece>(); // Initialize the list

    public Player(int id, string name, Colors color)
    {
        Id = id;
        Name = name;
        Color = color;
    }

    public void AddPiece(Piece piece)
    {
        Pieces.Add(piece);
    }
}

}