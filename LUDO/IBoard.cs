using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public interface IBoard
    {
        int Rows { get; }
        int Columns { get; }
        IPiece GetPieceAtPosition(int row, int col);
        void SetPieceAtPosition(IPiece piece, int row, int col);
        void RemovePiece(IPiece piece);
        void RemovePiece(IPiece piece, int row, int col);
        List<int> GetMoveHistory(IPiece piece);
        void MovePieceFromHome(IPiece piece);
        void MovePieceInPlay(IPiece piece, int steps);

        void MovePiece(IPiece piece, int steps);
        void Display();
    }
}
