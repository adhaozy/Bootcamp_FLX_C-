using System.Text;

namespace LudoLib
{
    /// <summary>
    /// Represents a Ludo board implementing the <see cref="IBoard"/> interface.
    /// </summary>
    public class Board : IBoard
    {
        
        private int[] _safePositions;
        private IPiece[,] boards;
        private Dictionary<IPiece, List<int>> moveHistory;
        private IPiece[,] board;

        /// <summary>
        /// Gets the number of rows on the board.
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// Gets the number of columns on the board.
        /// </summary>
        public int Columns { get; private set; }



        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows on the board.</param>
        /// <param name="columns">The number of columns on the board.</param>
        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            board = new IPiece[rows, columns];
            moveHistory = new Dictionary<IPiece, List<int>>();

            // setting vertical
            SetPieceAtPosition(new Piece(" O "), 0, 0);
            SetPieceAtPosition(new Piece(" O "), 0, 1);
            SetPieceAtPosition(new Piece(" O "), 0, 2);
            SetPieceAtPosition(new Piece(" O "), 0, 3);
            SetPieceAtPosition(new Piece(" O "), 0, 4);
            SetPieceAtPosition(new Piece(" O "), 0, 5);
            SetPieceAtPosition(new Piece(" O "), 0, 9);
            SetPieceAtPosition(new Piece(" O "), 0, 10);
            SetPieceAtPosition(new Piece(" O "), 0, 11);
            SetPieceAtPosition(new Piece(" O "), 0, 12);
            SetPieceAtPosition(new Piece(" O "), 0, 13);
            SetPieceAtPosition(new Piece(" O "), 0, 14);

            SetPieceAtPosition(new Piece(" O "), 5, 0);
            SetPieceAtPosition(new Piece(" O "), 5, 1);
            SetPieceAtPosition(new Piece(" O "), 5, 2);
            SetPieceAtPosition(new Piece(" O "), 5, 3);
            SetPieceAtPosition(new Piece(" O "), 5, 4);
            SetPieceAtPosition(new Piece(" O "), 5, 5);
            SetPieceAtPosition(new Piece(" O "), 5, 9);
            SetPieceAtPosition(new Piece(" O "), 5, 10);
            SetPieceAtPosition(new Piece(" O "), 5, 11);
            SetPieceAtPosition(new Piece(" O "), 5, 12);
            SetPieceAtPosition(new Piece(" O "), 5, 13);
            SetPieceAtPosition(new Piece(" O "), 5, 14);

            SetPieceAtPosition(new Piece(" O "), 9, 0);
            SetPieceAtPosition(new Piece(" O "), 9, 1);
            SetPieceAtPosition(new Piece(" O "), 9, 2);
            SetPieceAtPosition(new Piece(" O "), 9, 3);
            SetPieceAtPosition(new Piece(" O "), 9, 4);
            SetPieceAtPosition(new Piece(" O "), 9, 5);
            SetPieceAtPosition(new Piece(" O "), 9, 9);
            SetPieceAtPosition(new Piece(" O "), 9, 10);
            SetPieceAtPosition(new Piece(" O "), 9, 11);
            SetPieceAtPosition(new Piece(" O "), 9, 12);
            SetPieceAtPosition(new Piece(" O "), 9, 13);
            SetPieceAtPosition(new Piece(" O "), 9, 14);

            SetPieceAtPosition(new Piece(" O "), 14, 0);
            SetPieceAtPosition(new Piece(" O "), 14, 1);
            SetPieceAtPosition(new Piece(" O "), 14, 2);
            SetPieceAtPosition(new Piece(" O "), 14, 3);
            SetPieceAtPosition(new Piece(" O "), 14, 4);
            SetPieceAtPosition(new Piece(" O "), 14, 5);
            SetPieceAtPosition(new Piece(" O "), 14, 9);
            SetPieceAtPosition(new Piece(" O "), 14, 10);
            SetPieceAtPosition(new Piece(" O "), 14, 11);
            SetPieceAtPosition(new Piece(" O "), 14, 12);
            SetPieceAtPosition(new Piece(" O "), 14, 13);
            SetPieceAtPosition(new Piece(" O "), 14, 14);

            // setting hozontal ,

            SetPieceAtPosition(new Piece(" O "), 0, 0);
            SetPieceAtPosition(new Piece(" O "), 1, 0);
            SetPieceAtPosition(new Piece(" O "), 2, 0);
            SetPieceAtPosition(new Piece(" O "), 3, 0);
            SetPieceAtPosition(new Piece(" O "), 4, 0);
            SetPieceAtPosition(new Piece(" O "), 5, 0);
            SetPieceAtPosition(new Piece(" O "), 9, 0);
            SetPieceAtPosition(new Piece(" O "), 10, 0);
            SetPieceAtPosition(new Piece(" O "), 11, 0);
            SetPieceAtPosition(new Piece(" O "), 12, 0);
            SetPieceAtPosition(new Piece(" O "), 13, 0);
            SetPieceAtPosition(new Piece(" O "), 14, 0);

            SetPieceAtPosition(new Piece(" O "), 0, 5);
            SetPieceAtPosition(new Piece(" O "), 1, 5);
            SetPieceAtPosition(new Piece(" O "), 2, 5);
            SetPieceAtPosition(new Piece(" O "), 3, 5);
            SetPieceAtPosition(new Piece(" O "), 4, 5);
            SetPieceAtPosition(new Piece(" O "), 5, 5);
            SetPieceAtPosition(new Piece(" O "), 9, 5);
            SetPieceAtPosition(new Piece(" O "), 10, 5);
            SetPieceAtPosition(new Piece(" O "), 11, 5);
            SetPieceAtPosition(new Piece(" O "), 12, 5);
            SetPieceAtPosition(new Piece(" O "), 13, 5);
            SetPieceAtPosition(new Piece(" O "), 14, 5);

            SetPieceAtPosition(new Piece(" O "), 0, 9);
            SetPieceAtPosition(new Piece(" O "), 1, 9);
            SetPieceAtPosition(new Piece(" O "), 2, 9);
            SetPieceAtPosition(new Piece(" O "), 3, 9);
            SetPieceAtPosition(new Piece(" O "), 4, 9);
            SetPieceAtPosition(new Piece(" O "), 5, 9);
            SetPieceAtPosition(new Piece(" O "), 9, 9);
            SetPieceAtPosition(new Piece(" O "), 10, 9);
            SetPieceAtPosition(new Piece(" O "), 11, 9);
            SetPieceAtPosition(new Piece(" O "), 12, 9);
            SetPieceAtPosition(new Piece(" O "), 13, 9);
            SetPieceAtPosition(new Piece(" O "), 14, 9);

            SetPieceAtPosition(new Piece(" O "), 0, 14);
            SetPieceAtPosition(new Piece(" O "), 1, 14);
            SetPieceAtPosition(new Piece(" O "), 2, 14);
            SetPieceAtPosition(new Piece(" O "), 3, 14);
            SetPieceAtPosition(new Piece(" O "), 4, 14);
            SetPieceAtPosition(new Piece(" O "), 5, 14);
            SetPieceAtPosition(new Piece(" O "), 9, 14);
            SetPieceAtPosition(new Piece(" O "), 10, 14);
            SetPieceAtPosition(new Piece(" O "), 11, 14);
            SetPieceAtPosition(new Piece(" O "), 12, 14);
            SetPieceAtPosition(new Piece(" O "), 13, 14);
            SetPieceAtPosition(new Piece(" O "), 14, 14);

            SetPieceAtPosition(new Piece(" O "), 2, 2);
            SetPieceAtPosition(new Piece(" O "), 2, 3);
            SetPieceAtPosition(new Piece(" O "), 2, 11);
            SetPieceAtPosition(new Piece(" O "), 2, 12);

            SetPieceAtPosition(new Piece(" O "), 3, 2);
            SetPieceAtPosition(new Piece(" O "), 3, 3);
            SetPieceAtPosition(new Piece(" O "), 3, 11);
            SetPieceAtPosition(new Piece(" O "), 3, 12);

            SetPieceAtPosition(new Piece(" O "), 11, 2);
            SetPieceAtPosition(new Piece(" O "), 11, 3);
            SetPieceAtPosition(new Piece(" O "), 11, 11);
            SetPieceAtPosition(new Piece(" O "), 11, 12);

            SetPieceAtPosition(new Piece(" O "), 12, 2);
            SetPieceAtPosition(new Piece(" O "), 12, 3);
            SetPieceAtPosition(new Piece(" O "), 12, 11);
            SetPieceAtPosition(new Piece(" O "), 12, 12);



        }

        /// <summary>
        /// Gets the piece at the specified position on the board.
        /// </summary>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        /// <returns>The piece at the specified position or null if no piece is present.</returns>
        public IPiece GetPieceAtPosition(int row, int col)
        {
            return board[row, col];
        }

        /// <summary>
        /// Sets the specified piece at the given position on the board.
        /// </summary>
        /// <param name="piece">The piece to set on the board.</param>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        public void SetPieceAtPosition(IPiece piece, int row, int col)
        {
            board[row, col] = piece;

            // Initialize move history for the piece if it doesn't exist
            if (!moveHistory.ContainsKey(piece))
            {
                moveHistory[piece] = new List<int>();
            }
        }

        /// <summary>
        /// Removes the specified piece from the board.
        /// </summary>
        /// <param name="piece">The piece to remove from the board.</param>
        public void RemovePiece(IPiece piece)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (board[row, col] == piece)
                    {
                        board[row, col] = null;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Removes the specified piece from the board at the given position.
        /// </summary>
        /// <param name="piece">The piece to remove from the board.</param>
        /// <param name="row">The row of the position.</param>
        /// <param name="col">The column of the position.</param>
        public void RemovePiece(IPiece piece, int row, int col)
        {
            if (row >= 0 && row < Rows && col >= 0 && col < Columns)
            {
                if (board[row, col] == piece)
                {
                    board[row, col] = null;
                }
            }
        }

        /// <summary>
        /// Gets the move history for the specified piece.
        /// </summary>
        /// <param name="piece">The piece to retrieve the move history for.</param>
        /// <returns>The list of positions the piece has moved to.</returns>
        public List<int> GetMoveHistory(IPiece piece)
        {
            if (moveHistory.TryGetValue(piece, out var history))
            {
                return history;
            }

            return new List<int>();
        }

        // ... (other methods with documentation)

        /// <summary>
        /// Moves the specified piece from home to the in-play position (position 0).
        /// </summary>
        /// <param name="piece">The piece to move from home to in-play.</param>
        /// <returns>A message indicating the result of the move.</returns>
        public string MovePieceFromHome(IPiece piece)
        {
            // Move the piece from home to in-play (position 0)
            piece.CurrentPosition = 0;
            moveHistory[piece].Add(0);
            return $"Moved piece from home to in-play: {piece.PlayerNumber}, Piece {piece.PieceNumber} to position 0.";
        }

        /// <summary>
        /// Moves the specified piece on the board based on the given number of steps.
        /// </summary>
        /// <param name="piece">The piece to move on the board.</param>
        /// <param name="steps">The number of steps to move the piece.</param>
        /// <returns>A message indicating the result of the move.</returns>
        public string MovePieceInPlay(IPiece piece, int steps)
        {
            if (piece.CurrentPosition == -1)
            {
                return $"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} is not on the board.";
            }
            else
            {
                // Continue with the logic to move the piece based on the dice roll
                int currentRow = piece.CurrentPosition / Columns;
                int currentCol = piece.CurrentPosition % Columns;

                // Calculate the new position
                int newRow = currentRow + steps / Columns;
                int newCol = (currentCol + steps) % Columns;

                // Simulate safe zone logic
                if ((piece.CurrentPosition >= 49 && piece.CurrentPosition <= 55) || (piece.CurrentPosition >= 0 && piece.CurrentPosition <= 6))
                {
                    return $"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} entered a safe zone!";
                }

                // Update the piece's position
                int newPosition = newRow * Columns + newCol;
                piece.CurrentPosition = newPosition;

                return $"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} moved to position ({newRow}, {newCol}).";
            }
        }


        // ... (other methods with documentation)

        /// <summary>
        /// Gets a string representation of the current state of the board.
        /// </summary>
        /// <returns>A string representing the current state of the board.</returns>
        public string GetBoardAsString()
        {
            StringBuilder boardString = new StringBuilder();

            boardString.AppendLine("Current Board:");

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    IPiece piece = GetPieceAtPosition(row, col);
                    if (piece != null)
                    {
                        boardString.Append($"[{piece.PlayerNumber},{piece.PieceNumber}] ");
                    }
                    else
                    {
                        boardString.Append("[   ] ");
                    }
                }
                boardString.AppendLine();
            }

            boardString.AppendLine();

            return boardString.ToString();
        }

        /// <summary>
        /// Moves the specified piece a specified number of steps on the board.
        /// </summary>
        /// <param name="piece">The piece to move.</param>
        /// <param name="steps">The number of steps to move the piece.</param>
        public void MovePiece(IPiece piece, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                // Melakukan pergerakan 1 langkah pada setiap iterasi
                MovePieceInPlay(piece, 1);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class with the specified board size.
        /// </summary>
        /// <param name="boardSize">The size of the board.</param>
        public Board(int boardSize)
        {
            // Initialize the board and safe positions
            _safePositions = new int[boardSize];
            SetSafeSquares();
        }

        /// <summary>
        /// Sets the safe squares on the board.
        /// </summary>
        public void SetSafeSquares()
        {
            // Set safe squares on the board
            for (int i = 0; i < _safePositions.Length; i++)
            {
                // Example: Set every 5th position as safe
                if ((i + 1) % 5 == 0)
                {
                    _safePositions[i] = 1; // You can use any value to represent a safe square
                }
                else
                {
                    _safePositions[i] = 0;
                }
            }
        }

        /// <summary>
        /// Gets an array representing the safe squares on the board.
        /// </summary>
        /// <returns>An array indicating the safe squares on the board.</returns>
        public int[] GetSafeSquares()
        {
            return _safePositions;
        }
    }
}