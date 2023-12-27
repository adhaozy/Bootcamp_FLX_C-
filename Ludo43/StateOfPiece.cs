namespace LudoLib
{
    /// <summary>
    /// Represents the possible states of a game piece in a Ludo game.
    /// </summary>
    public enum StateOfPiece
    {
        /// <summary>
        /// The game piece is currently in play on the board.
        /// </summary>
        InPlay,

        /// <summary>
        /// The game piece is at home, typically at the start of the game or after being sent back home.
        /// </summary>
        Home,

        /// <summary>
        /// The game piece is in a safe zone.
        /// </summary>
        Safe,

        /// <summary>
        /// The game piece has reached its final destination or goal.
        /// </summary>
        Finished
    }
}
