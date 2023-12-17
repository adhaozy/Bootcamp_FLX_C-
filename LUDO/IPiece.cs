using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public interface IPiece
    {
        string Condition { get; set; } // At home "home", In the game (on the highway) "ingame", In the endgame "endgame", Finished (in goal) "goal"
        string Color { get; } // Color
        int Position { get; } // Actual position
        int StartPosition { get; } // StartPosition
        int EndPosition { get; } // EndPosition

        string PlayerNumber { get; set; }
        string PieceNumber { get; set; }
        int CurrentPosition { get; set; }

        void Move(int steps);
        void SetCondition(string condition);
        string GetCondition();
        void InitializePiece(int playerNumber, int pieceNumber);
        void MovePiece(int steps);
    }
}
