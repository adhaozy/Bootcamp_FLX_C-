using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{

    public class Piece : IPiece
    {
        public int PlayerNumber { get; private set; }
        public int PieceNumber { get; private set; }
        public int CurrentPosition { get; set; }

        public Piece()
        {
            // Default constructor
        }

        public void InitializePiece(int playerNumber, int pieceNumber)
        {
            PlayerNumber = playerNumber;
            PieceNumber = pieceNumber;
            CurrentPosition = -1; // Not on the board initially
        }

        public void MovePiece(int steps)
        {
            // Validate that the piece is in play (not at home or removed)
            if (CurrentPosition == -1)
            {
                Console.WriteLine($"Piece {PlayerNumber}, Piece {PieceNumber} is not on the board.");
            }
            else
            {
                // Continue with the logic to move the piece based on the dice roll
                int newPosition = (CurrentPosition + steps) % 100; // Assuming a 14x4 Ludo board

                // Simulate safe zone logic
                if ((newPosition >= 49 && newPosition <= 55) || (newPosition >= 0 && newPosition <= 6))
                {
                    Console.WriteLine($"Piece {PlayerNumber}, Piece {PieceNumber} entered a safe zone!");
                }

                CurrentPosition = newPosition;
                Console.WriteLine($"Piece {PlayerNumber}, Piece {PieceNumber} moved to position {newPosition}.");
            }
        }
    }

}
