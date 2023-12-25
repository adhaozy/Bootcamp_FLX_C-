namespace LudoLib
{
    /// <summary>
    /// Represents a piece in a Ludo game.
    /// </summary>
    public interface IPiece
    {
        /// <summary>
        /// Gets or sets the condition of the piece.
        /// Possible values: "home", "ingame", "endgame", "goal".
        /// </summary>
        string Condition { get; set; }

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        string Color { get; }

        /// <summary>
        /// Gets the current position of the piece on the board.
        /// </summary>
        int Position { get; }

        /// <summary>
        /// Gets the start position of the piece on the board.
        /// </summary>
        int StartPosition { get; }

        /// <summary>
        /// Gets the end position of the piece on the board.
        /// </summary>
        int EndPosition { get; }

        /// <summary>
        /// Gets or sets the player number associated with the piece.
        /// </summary>
        string PlayerNumber { get; set; }

        /// <summary>
        /// Gets or sets the piece number.
        /// </summary>
        string PieceNumber { get; set; }

        /// <summary>
        /// Gets or sets the current position of the piece on the board.
        /// </summary>
        int CurrentPosition { get; set; }

        /// <summary>
        /// Moves the piece on the board by the specified number of steps.
        /// </summary>
        /// <param name="steps">The number of steps to move the piece.</param>
        void Move(int steps);

        /// <summary>
        /// Sets the condition of the piece.
        /// </summary>
        /// <param name="condition">The new condition of the piece.</param>
        void SetCondition(string condition);

        /// <summary>
        /// Gets the current condition of the piece.
        /// </summary>
        /// <returns>The current condition of the piece.</returns>
        string GetCondition();

        /// <summary>
        /// Initializes the piece with the specified player number and piece number.
        /// </summary>
        /// <param name="playerNumber">The player number associated with the piece.</param>
        /// <param name="pieceNumber">The piece number.</param>
        void InitializePiece(int playerNumber, int pieceNumber);

        /// <summary>
        /// Moves the piece on the board by the specified number of steps.
        /// </summary>
        /// <param name="steps">The number of steps to move the piece.</param>
        /// <returns>A message indicating the result of the move.</returns>
        string MovePiece(int steps);

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        /// <returns>The color of the piece.</returns>
        GameColor GetColor();

        /// <summary>
        /// Gets the state of the piece.
        /// </summary>
        /// <returns>The state of the piece.</returns>
        StateOfPiece GetState();

        /// <summary>
        /// Sets the state of the piece.
        /// </summary>
        /// <param name="state">The new state of the piece.</param>
        void SetState(StateOfPiece state);

        /// <summary>
        /// Sets the position of the piece on the board.
        /// </summary>
        /// <param name="pos">The new position of the piece.</param>
        void SetPos(int pos);

        /// <summary>
        /// Gets the position of the piece on the board.
        /// </summary>
        /// <returns>The position of the piece.</returns>
        int GetPos();

        /// <summary>
        /// Checks if the piece has been killed.
        /// </summary>
        /// <returns>True if the piece has been killed; otherwise, false.</returns>
        bool IsKilled();
    }
}
