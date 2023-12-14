using ITD.OOP1.Ludo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public class LudoBoard : IBoard
    {
        private int[,] board;
    private bool[,] playerStarted;
    private bool[,] eliminatedPlayers;

    public LudoBoard(int rows, int columns)
    {
        board = new int[rows, columns];
    }

    public void InitializeBoard(int numberOfPlayers, int piecesPerPlayer)
    {
        playerStarted = new bool[numberOfPlayers, piecesPerPlayer];
        eliminatedPlayers = new bool[numberOfPlayers, piecesPerPlayer];
    }

    public void DisplayBoard()
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                int playerNumber = board[i, j];
                Console.Write(playerNumber > 0 ? $"P{playerNumber}\t" : "0\t");
            }
            Console.WriteLine();
        }
    }

    public void MovePlayerPiece(int playerNumber, int pieceNumber, int steps)
    {
        int currentPosition = GetPlayerPiecePosition(playerNumber, pieceNumber);

        // If the piece is not found, initialize it at the start position
        if (currentPosition == -1)
        {
            currentPosition = 0; // Set the current position to 0
            board[0, 0] = playerNumber;
            playerStarted[playerNumber - 1, pieceNumber - 1] = true;
            Console.WriteLine($"Player {playerNumber}, Piece {pieceNumber} placed at position 0.");
            return;
        }

        int newPosition = (currentPosition + steps) % (board.GetLength(0) * board.GetLength(1));

        // Check for special positions like the end and loop around if necessary
        if (newPosition == board.GetLength(0) * board.GetLength(1))
        {
            newPosition = 0;
        }

        // Check if the new position is a safe zone
        if (IsPlayerInSafeZone(playerNumber, pieceNumber, newPosition))
        {
            Console.WriteLine($"Player {playerNumber}, Piece {pieceNumber} entered a safe zone!");
        }

        // If not in a safe zone, check for collisions and eliminate the other player's piece
        int playerAtNewPosition = board[newPosition / board.GetLength(1), newPosition % board.GetLength(1)];
        if (playerAtNewPosition > 0 && playerAtNewPosition != playerNumber)
        {
            EliminatePlayerPiece(playerNumber, playerAtNewPosition, pieceNumber);
        }

        // Move the piece to the new position
        board[currentPosition / board.GetLength(1), currentPosition % board.GetLength(1)] = 0; // Clear the current position
        board[newPosition / board.GetLength(1), newPosition % board.GetLength(1)] = playerNumber; // Set the new position
    }

    public bool IsPlayerInSafeZone(int playerNumber, int pieceNumber, int position)
    {
        // In this example, the safe zone is the last row of the board
        return position / board.GetLength(1) == board.GetLength(0) - 1;
    }

    public void EliminatePlayerPiece(int eliminatingPlayer, int eliminatedPlayer, int pieceNumber)
    {
        if (eliminatingPlayer != eliminatedPlayer)
        {
            Console.WriteLine($"Player {eliminatingPlayer}, Piece {pieceNumber} eliminated Player {eliminatedPlayer}, Piece {pieceNumber}!");
            int eliminatedPiecePosition = GetPlayerPiecePosition(eliminatedPlayer, pieceNumber);
            if (eliminatedPiecePosition != -1)
            {
                board[eliminatedPiecePosition / board.GetLength(1), eliminatedPiecePosition % board.GetLength(1)] = 0;
                eliminatedPlayers[eliminatedPlayer - 1, pieceNumber - 1] = true;
            }
        }
    }

    public int GetPlayerPiecePosition(int playerNumber, int pieceNumber)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == playerNumber && playerStarted[playerNumber - 1, pieceNumber - 1] && !eliminatedPlayers[playerNumber - 1, pieceNumber - 1])
                {
                    return i * board.GetLength(1) + j;
                }
            }
        }

        return -1; // Player or piece not found
    }

    public bool IsPlayerEliminated(int playerNumber)
    {
        for (int i = 0; i < eliminatedPlayers.GetLength(1); i++)
        {
            if (!eliminatedPlayers[playerNumber - 1, i])
            {
                return false; // At least one piece of the player is still in the game
            }
        }

        return true; // All pieces of the player are eliminated
    }
    }
 
}