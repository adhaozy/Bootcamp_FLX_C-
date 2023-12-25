namespace LudoLib
{
    /// <summary>
    /// Represents a piece in a Ludo game.
    /// </summary>
    public class Piece : IPiece
        {
        private int _pos;
        private GameColor _color;
        private StateOfPiece _state;

        /// <summary>
        /// Gets or sets the player number associated with the piece.
        /// </summary>
        public string PlayerNumber { get; set; }

        /// <summary>
        /// Gets or sets the piece number.
        /// </summary>
        public string PieceNumber { get; set; }

        /// <summary>
        /// Gets or sets the current position of the piece on the board.
        /// </summary>
        public int CurrentPosition { get; set; }

        /// <summary>
        /// Gets or sets the condition of the piece.
        /// Possible values: "Home", "Ingame", "Endgame", "Goal".
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets the current position of the piece on the board.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets the start position of the piece on the board.
        /// </summary>
        public int StartPosition { get; }

        /// <summary>
        /// Gets the end position of the piece on the board.
        /// </summary>
        public int EndPosition { get; }

        /// <summary>
        /// Gets the symbol representing the piece.
        /// </summary>
        public string Symbol { get; private set; }

        /// <summary>
        /// Default constructor for the Piece class.
        /// </summary>
        public Piece()
        {
            // Default constructor
        }

        /// <summary>
        /// Initializes a new instance of the Piece class with the specified color.
        /// </summary>
        /// <param name="color">The color of the piece.</param>
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

        /// <summary>
        /// Moves the piece on the board by the specified number of steps.
        /// </summary>
        /// <param name="steps">The number of steps to move the piece.</param>
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

        /// <summary>
        /// Sets the condition of the piece.
        /// </summary>
        /// <param name="condition">The new condition of the piece.</param>
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

        /// <summary>
        /// Gets the current condition of the piece.
        /// </summary>
        /// <returns>The current condition of the piece.</returns>
        public string GetCondition()
        {
            return this.Condition;
        }

        /// <summary>
        /// Returns a string representation of the piece.
        /// </summary>
        /// <returns>A string representation of the piece.</returns>
        public override string ToString()
        {
            return $"[Kondisi Bidak : {this.Condition} , Position :{this.Position % 57}, Color : {this.Color}]";
        }

        /// <summary>
        /// Initializes the piece with the specified player number and piece number.
        /// </summary>
        /// <param name="playerNumber">The player number associated with the piece.</param>
        /// <param name="pieceNumber">The piece number.</param>
        public void InitializePiece(int playerNumber, int pieceNumber)
        {
            PlayerNumber = playerNumber.ToString();
            PieceNumber = pieceNumber.ToString();
            CurrentPosition = -1; // Set an initial value as needed
        }

        /// <summary>
        /// Moves the piece on the board by the specified number of steps.
        /// </summary>
        /// <param name="steps">The number of steps to move the piece.</param>
        /// <returns>A message indicating the result of the move.</returns>
        public string MovePiece(int steps)
        {
            // Validate that the piece is in play (not at home or removed)
            if (CurrentPosition == -1)
            {
                return $"Piece {PlayerNumber}, Piece {PieceNumber} is not on the board.";
            }
            else
            {
                // Continue with the logic to move the piece based on the dice roll
                int newPosition = (CurrentPosition + steps) % 100; // Assuming a 14x4 Ludo board

                // Simulate safe zone logic
                if ((newPosition >= 49 && newPosition <= 55) || (newPosition >= 0 && newPosition <= 6))
                {
                    return $"Piece {PlayerNumber}, Piece {PieceNumber} entered a safe zone!";
                }

                CurrentPosition = newPosition;
                return $"Piece {PlayerNumber}, Piece {PieceNumber} moved to position {newPosition}.";
            }
        }

        /// <summary>
        /// Gets the color of the piece.
        /// </summary>
        /// <returns>The color of the piece.</returns>
        public GameColor GetColor()
        {
            return _color;
        }

        /// <summary>
        /// Gets the state of the piece.
        /// </summary>
        /// <returns>The state of the piece.</returns>
        public StateOfPiece GetState()
        {
            return _state;
        }

        /// <summary>
        /// Sets the state of the piece.
        /// </summary>
        /// <param name="state">The new state of the piece.</param>
        public void SetState(StateOfPiece state)
        {
            _state = state;
        }

        /// <summary>
        /// Sets the position of the piece on the board.
        /// </summary>
        /// <param name="pos">The new position of the piece.</param>
        public void SetPos(int pos)
        {
            _pos = pos;
        }

        /// <summary>
        /// Gets the position of the piece on the board.
        /// </summary>
        /// <returns>The position of the piece.</returns>
        public int GetPos()
        {
            return _pos;
        }

        /// <summary>
        /// Checks if the piece has been killed.
        /// </summary>
        /// <returns>True if the piece has been killed; otherwise, false.</returns>
        public bool IsKilled()
        {
            return _state == StateOfPiece.Finished;
        }
    }
}