namespace LudoLib
{
    // Define the IPlayer interface
    public interface IPlayer
{
    int Id { get; set; }
    string Name { get; set; }
    

    List<Piece> Pieces { get; } // Add a property for the player's pieces

   

    void AddTeam(Team team);

    string GetName { get; }
    GameColor Color { get; }
    int GetPlayerId();
    string GetDescription();
    Team[] GetTokens();
    }



}