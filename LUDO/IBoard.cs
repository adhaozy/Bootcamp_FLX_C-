using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public interface IBoard
    {
    void InitializeBoard(int numberOfPlayers, int piecesPerPlayer);
    void DisplayBoard();
    void MovePlayerPiece(int playerNumber, int pieceNumber, int steps);
    bool IsPlayerInSafeZone(int playerNumber, int pieceNumber, int position);
    void EliminatePlayerPiece(int eliminatingPlayer, int eliminatedPlayer, int pieceNumber);
    int GetPlayerPiecePosition(int playerNumber, int pieceNumber);
    bool IsPlayerEliminated(int playerNumber);
    }
}
