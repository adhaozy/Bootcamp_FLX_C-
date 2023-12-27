namespace LudoLib
{
    /// <summary>
    /// Represents the interface for a Ludo game board.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Gets the number of rows on the board.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// Gets the number of columns on the board.
        /// </summary>
        int Columns { get; }

        /// <summary>
        /// Gets the piece at the specified position on the board.
        /// </summary>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        /// <returns>The piece at the specified position or null if no piece is present.</returns>
        IPiece GetPieceAtPosition(int row, int col);

        /// <summary>
        /// Sets the specified piece at the given position on the board.
        /// </summary>
        /// <param name="piece">The piece to set on the board.</param>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        void SetPieceAtPosition(IPiece piece, int row, int col);

        /// <summary>
        /// Removes the specified piece from the board.
        /// </summary>
        /// <param name="piece">The piece to remove from the board.</param>
        void RemovePiece(IPiece piece);

        /// <summary>
        /// Removes the specified piece from the board at the given position.
        /// </summary>
        /// <param name="piece">The piece to remove from the board.</param>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        void RemovePiece(IPiece piece, int row, int col);

        /// <summary>
        /// Gets the move history for the specified piece.
        /// </summary>
        /// <param name="piece">The piece to retrieve the move history for.</param>
        /// <returns>The list of positions the piece has moved to.</returns>
        List<int> GetMoveHistory(IPiece piece);

        /// <summary>
        /// Moves the specified piece from home to the in-play position (position 0).
        /// </summary>
        /// <param name="piece">The piece to move from home to in-play.</param>
        /// <returns>A message indicating the result of the move.</returns>
        string MovePieceFromHome(IPiece piece);

        /// <summary>
        /// Moves the specified piece on the board based on the given number of steps.
        /// </summary>
        /// <param name="piece">The piece to move on the board.</param>
        /// <param name="steps">The number of steps to move the piece.</param>
        /// <returns>A message indicating the result of the move.</returns>
        string MovePieceInPlay(IPiece piece, int steps);

        /// <summary>
        /// Moves the specified piece a specified number of steps on the board.
        /// </summary>
        /// <param name="piece">The piece to move.</param>
        /// <param name="steps">The number of steps to move the piece.</param>
        void MovePiece(IPiece piece, int steps);

        /// <summary>
        /// Gets a string representation of the current state of the board.
        /// </summary>
        /// <returns>A string representing the current state of the board.</returns>
        string GetBoardAsString();

        /// <summary>
        /// Sets the safe squares on the board.
        /// </summary>
        void SetSafeSquares();

        /// <summary>
        /// Gets an array representing the safe squares on the board.
        /// </summary>
        /// <returns>An array indicating the safe squares on the board.</returns>
        int[] GetSafeSquares();
    }
}
