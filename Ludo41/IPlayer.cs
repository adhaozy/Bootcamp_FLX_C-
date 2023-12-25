namespace LudoLib
{
    /// <summary>
    /// Represents a player in a Ludo game.
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Gets or sets the unique identifier of the player.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the list of pieces owned by the player.
        /// </summary>
        List<Piece> Pieces { get; }

        /// <summary>
        /// Adds a team to the player's collection of teams.
        /// </summary>
        /// <param name="team">The team to add to the player.</param>
        void AddTeam(Team team);

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <returns>The name of the player.</returns>
        string GetName();

        /// <summary>
        /// Gets the color associated with the player.
        /// </summary>
        /// <returns>The color of the player.</returns>
        GameColor GetColor();

        /// <summary>
        /// Gets the unique identifier of the player.
        /// </summary>
        /// <returns>The unique identifier of the player.</returns>
        int GetPlayerId();

        /// <summary>
        /// Gets a description of the player.
        /// </summary>
        /// <returns>A description of the player.</returns>
        string GetDescription();

        /// <summary>
        /// Gets an array of teams associated with the player.
        /// </summary>
        /// <returns>An array of teams associated with the player.</returns>
        Team[] GetTokens();
    }
}
