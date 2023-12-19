namespace LudoLib
{
    public class Piece : IPiece
        {
        private int _pos;
        private Colors _color;
        private StateOfPiece _state;

        

        public Piece(Colors color)
        {
            _color = color;
            _state = StateOfPiece.Home;
        }

        public Colors GetColor()
        {
            return _color;
        }

        public StateOfPiece GetState()
        {
            return _state;
        }

        public void SetState(StateOfPiece state)
        {
            _state = state;
        }

        public void SetPos(int pos)
        {
            _pos = pos;
        }

        public int GetPos()
        {
            return _pos;
        }

        public bool IsKilled()
        {
            return _state == StateOfPiece.Finished;
        }
    }
}