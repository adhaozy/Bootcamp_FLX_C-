namespace LudoLib
{
    public interface IPiece
    {
        GameColor GetColor();
        StateOfPiece GetState();
        void SetState(StateOfPiece state);
        void SetPos(int pos);
        int GetPos();
        bool IsKilled();
    }
}