using ITD.OOP1.Ludo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public class LudoBoard : IBoard
    {
        private IPiece[,] board;
        private Dictionary<IPiece, List<int>> moveHistory;

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public LudoBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            board = new IPiece[rows, columns];
            moveHistory = new Dictionary<IPiece, List<int>>();
        }

        public IPiece GetPieceAtPosition(int row, int col)
        {
            return board[row, col];
        }

        public void SetPieceAtPosition(IPiece piece, int row, int col)
        {
            board[row, col] = piece;

            // Initialize move history for the piece if it doesn't exist
            if (!moveHistory.ContainsKey(piece))
            {
                moveHistory[piece] = new List<int>();
            }
        }

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

        public List<int> GetMoveHistory(IPiece piece)
        {
            if (moveHistory.TryGetValue(piece, out var history))
            {
                return history;
            }

            return new List<int>();
        }

        public void MovePieceFromHome(IPiece piece)
        {
            // Move the piece from home to in-play (position 0)
            piece.CurrentPosition = 0;
            moveHistory[piece].Add(0);
            Console.WriteLine($"Moved piece from home to in-play: {piece.PlayerNumber}, Piece {piece.PieceNumber} to position 0.");
        }

        public void MovePieceInPlay(IPiece piece, int steps)
        {
            if (piece.CurrentPosition == -1)
            {
                Console.WriteLine($"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} is not on the board.");
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
                    Console.WriteLine($"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} entered a safe zone!");
                }

                // Update the piece's position
                int newPosition = newRow * Columns + newCol;
                piece.CurrentPosition = newPosition;

                Console.WriteLine($"Piece {piece.PlayerNumber}, Piece {piece.PieceNumber} moved to position ({newRow}, {newCol}).");
            }
        }


        public void Display()
        {
        Console.WriteLine("Current Board:");

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    IPiece piece = GetPieceAtPosition(row, col);
                    if (piece != null)
                    {
                        Console.Write($"[{piece.PlayerNumber},{piece.PieceNumber}] ");
                    }
                    else
                    {
                        Console.Write("[   ] ");
                    }
                }
                Console.WriteLine();
            }

        Console.WriteLine();
        }
    }
}