namespace LudoLib
{
    public class Team
    {
        private Piece[] _pieces;
        private GameColor _color;
        private List<Piece> _piecess;

        public TokenState State
        {
            get { return this.state; }
            set { state = value; }
        } 
        public Team()
        {
            // Default state is Home when a player is created
            this.state = TokenState.Home;
        }
        public Team(int colorIndex, GameColor color)
        {
            _color = color;
            _piecess = new List<Piece>();
        }

        // Existing code...

        // Add a method to add a piece to the team
        public void AddPiece(Piece piece)
        {
            _piecess.Add(piece);
        }
        public Team(GameColor color)
        {
            _color = color;
            _pieces = new Piece[4];

            // Initialize pieces for the team
            for (int i = 0; i < _pieces.Length; i++)
            {
                _pieces[i] = new Piece(color);
            }
        }

        public Piece[] GetPieces()
        {
            return _pieces;
        }

        public GameColor GetColor()
        {
            return _color;
        }

        public void SetPieceState(int pieceIndex, StateOfPiece state)
        {
            if (pieceIndex >= 0 && pieceIndex < _pieces.Length)
            {
                _pieces[pieceIndex].SetState(state);
            }
        }

        public void MovePiece(int pieceIndex, int newPosition)
        {
            if (pieceIndex >= 0 && pieceIndex < _pieces.Length)
            {
                _pieces[pieceIndex].SetPos(newPosition);
            }
        }

        public void KillPiece(int pieceIndex)
        {
            SetPieceState(pieceIndex, StateOfPiece.Finished);
        }

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