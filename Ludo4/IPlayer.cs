namespace LudoLib
{
    // Define the IPlayer interface
    public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }
    Colors Color { get; set; }

    List<Piece> Pieces { get; } // Add a property for the player's pieces

    void AddPiece(Piece piece); // Add a method to add a piece to the player
}

}