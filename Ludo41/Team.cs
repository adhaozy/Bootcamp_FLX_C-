namespace LudoLib
{
    /// <summary>
    /// Represents the possible states of a token within a team.
    /// </summary>
    public enum TokenState { Home, InPlay, Safe };

    /// <summary>
    /// Represents a team in a Ludo game with its associated pieces and properties.
    /// </summary>
    public class Team
    {
        private int tokenId;
        private Piece[] _pieces;
        private GameColor _color;
        private List<Piece> _piecess;
        private TokenState state;
        internal readonly bool Value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class with the specified ID and color.
        /// </summary>
        /// <param name="id">The unique identifier of the team.</param>
        /// <param name="clr">The color of the team.</param>
        public Team(int id, GameColor clr)
        {
            this.tokenId = id;
            this._color = clr;
            this.state = TokenState.Home;
        }

        /// <summary>
        /// Adds a piece to the team.
        /// </summary>
        /// <param name="piece">The piece to add to the team.</param>
        public void AddPiece(Piece piece)
        {
            _piecess.Add(piece);
        }

        /// <summary>
        /// Gets the state of the team's tokens.
        /// </summary>
        public TokenState State
        {
            get { return this.state; }
            set { state = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class with default values.
        /// Default state is Home when a team is created.
        /// </summary>
        public Team()
        {
            this.state = TokenState.Home;
        }

        /// <summary>
        /// Gets the unique identifier of the team.
        /// </summary>
        /// <returns>The unique identifier of the team.</returns>
        public int GetTokenId()
        {
            return this.tokenId;
        }

        /// <summary>
        /// Gets the color of the team.
        /// </summary>
        /// <returns>The color of the team.</returns>
        public GameColor GetColor()
        {
            return this._color;
        }

        /// <summary>
        /// Gets the state of the team's tokens.
        /// </summary>
        /// <returns>The state of the team's tokens.</returns>
        public TokenState GetState()
        {
            return this.state;
        }

        /// <summary>
        /// Gets the array of pieces associated with the team.
        /// </summary>
        /// <returns>The array of pieces associated with the team.</returns>
        public Piece[] GetPieces()
        {
            return _pieces;
        }

        /// <summary>
        /// Sets the state of a specific piece within the team.
        /// </summary>
        /// <param name="pieceIndex">The index of the piece within the team.</param>
        /// <param name="state">The new state to set for the piece.</param>
        public void SetPieceState(int pieceIndex, StateOfPiece state)
        {
            if (pieceIndex >= 0 && pieceIndex < _pieces.Length)
            {
                _pieces[pieceIndex].SetState(state);
            }
        }

        /// <summary>
        /// Moves a specific piece within the team to a new position.
        /// </summary>
        /// <param name="pieceIndex">The index of the piece within the team.</param>
        /// <param name="newPosition">The new position to set for the piece.</param>
        public void MovePiece(int pieceIndex, int newPosition)
        {
            if (pieceIndex >= 0 && pieceIndex < _pieces.Length)
            {
                _pieces[pieceIndex].SetPos(newPosition);
            }
        }

        /// <summary>
        /// Marks a specific piece within the team as killed or finished.
        /// </summary>
        /// <param name="pieceIndex">The index of the piece within the team.</param>
        public void KillPiece(int pieceIndex)
        {
            SetPieceState(pieceIndex, StateOfPiece.Finished);
        }

        /// <summary>
        /// Checks if a specific piece within the team has been killed.
        /// </summary>
        /// <param name="pieceIndex">The index of the piece within the team.</param>
        /// <returns>True if the piece has been killed; otherwise, false.</returns>
        public bool IsPieceKilled(int pieceIndex)
        {
            if (pieceIndex >= 0 && pieceIndex < _pieces.Length)
            {
                return _pieces[pieceIndex].IsKilled();
            }
            return false;
        }
    }
}
