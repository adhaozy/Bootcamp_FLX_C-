using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public class Board : IBoard
    {
        
            private IPiece[,] board;
            private Dictionary<IPiece, List<int>> moveHistory;

            public int Rows { get; private set; }
            public int Columns { get; private set; }

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
            public void MovePiece(IPiece piece, int steps)
            {
                for (int i = 0; i < steps; i++)
                {
                    // Melakukan pergerakan 1 langkah pada setiap iterasi
                    MovePieceInPlay(piece, 1);
                }
            }

            

    }

}
