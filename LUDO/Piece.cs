using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{

    public class Piece : IPiece
    {
        public string PlayerNumber { get; set; }
        public string PieceNumber { get; set; }
        public int CurrentPosition { get; set; }
        public string Condition { get; set; }
        public string Color { get; }
        public int Position { get; set; }
        public int StartPosition { get; }
        public int EndPosition { get; }

        public string Symbol { get; private set; }

        public Piece()
        {
            // Default constructor
        }
        public Piece(string color)
        {
            this.Color = color;
            this.SetCondition("Home");

            switch (color)
            {
                case "Red":
                    this.Position = 0;
                    this.StartPosition = 0;
                    this.EndPosition = 57;
                    break;
                case "Green":
                    this.Position = 14 % 57;
                    this.StartPosition = 14;
                    this.EndPosition = 71;
                    break;
                case "Yellow":
                    this.Position = 28 % 57;
                    this.StartPosition = 28;
                    this.EndPosition = 85;
                    break;
                case "Blue":
                    this.Position = 42 % 57;
                    this.StartPosition = 42;
                    this.EndPosition = 99;
                    break;
            }
        }

        public void Move(int steps)
        {
            this.Position += steps;

            if (this.Position > this.EndPosition)
            {
                this.SetCondition("Endgame");
            }

            if (this.Position > this.EndPosition + 5)
            {
                this.SetCondition("Goal");
            }
        }

        public void SetCondition(string condition)
        {
            switch (condition)
            {
                case "Home":
                    this.Condition = "Home";
                    break;
                case "Ingame":
                    this.Condition = "Ingame";
                    break;
                case "Endgame":
                    this.Condition = "Endgame";
                    break;
                case "Goal":
                    this.Condition = "Goal";
                    break;
            }
        }

        public string GetCondition()
        {
            return this.Condition;
        }

        public override string ToString()
        {
            return $"[Kondisi Bidak : {this.Condition} , Position :{this.Position % 57}, Color : {this.Color}]";
        }

        // line
        public void InitializePiece(int playerNumber, int pieceNumber)
        {
            PlayerNumber = playerNumber.ToString();
            PieceNumber = pieceNumber.ToString();
            CurrentPosition = -1; // Set an initial value as needed
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
