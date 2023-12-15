using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public interface IPiece
    {
        int PlayerNumber { get; }
        int PieceNumber { get; }
        int CurrentPosition { get; set; }

        void InitializePiece(int playerNumber, int pieceNumber);
        void MovePiece(int steps);
    }
}
