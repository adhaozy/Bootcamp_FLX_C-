using Ludo4;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LudoLib
{  
            public class GameController
            {
                private Dice _dice;
                private List<IPlayer> _players;
                private int _turn;
                private IPlayer _player;
                //private int playerTurn = 1;
                //private IBoard _board; // Add a private field for the board
                public GameModes GameModes { get; private set; }

                private Dictionary<IPlayer, Dictionary<Piece, StateOfPiece>> _pieceStates;
            
            public GameController() { }

            public GameController(int minDiceValue, int maxDiceValue)
            {
                _dice = new Dice(minDiceValue, maxDiceValue);
                _players = new List<IPlayer>();
                //_board = board;
                _pieceStates = new Dictionary<IPlayer, Dictionary<Piece, StateOfPiece>>();

                //_board.SetSafeSquares();
            }

        // Method to add a player to the list of players
            public StateOfPiece GetPieceState(IPlayer player, Piece piece)
            {
                if (_pieceStates.ContainsKey(player) && _pieceStates[player].ContainsKey(piece))
                {
                    return _pieceStates[player][piece];
                }

                return StateOfPiece.Home; // Default to Home if not found
            }

            // Existing code...

            // Method to add a player to the list of players
            

            // Property to access the Dice instance
            public Dice Dice => _dice;

            // Property to access the list of players
            public List<IPlayer> Players => _players;

            // Property to access the board
            //public IBoard Board => _board;


           

            

            public string ShowTurn()
            {
                // Create a StringBuilder to build the output
                StringBuilder output = new StringBuilder();
                output.AppendLine("Current Game State:");

                foreach (IPlayer player in Players)
                {
                    output.AppendLine($"Player Name: {player.Name}, Color: {player.Color}");

                    // Access the player's pieces
                    foreach (Piece piece in player.Pieces)
                    {
                        // Do something with each piece
                        output.AppendLine($"  Piece Color: {piece.GetColor()}, Piece State: {piece.GetState()}");
                    }
                }

                output.AppendLine(); // Add a newline at the end

                // Return the built string
                return output.ToString();
            }

            public void ForceKillPiece(List<Team> teams)
            {
                // Implement your logic to force kill a piece
            }

            public bool IsWin()
            {
                // Implement your logic to check if a team has won
                return false;
            }

            public void SetMode(GameModes mode)
            {
                // Implement your logic to set the game mode
            }

            public GameModes GetMode()
            {
                // Implement your logic to get the game mode
                return GameModes.LOCAL;
            }

            public void OnPlayerPos(string message)
            {
                // Implement your logic for handling player position events
            }

            public void OnPieceState(Piece[] pieces, string message)
            {
                // Implement your logic for handling piece state events
            }

        // ... rest of your LudoGameController code

            public int ChangeTurn(int numberOfPlayers, int currentPlayerTurn)
            {
                if (currentPlayerTurn == numberOfPlayers)
                {
                    currentPlayerTurn = 1;
                }
                else
                {
                    currentPlayerTurn++;
                }

                // Omitted Console.Write statements

                return currentPlayerTurn;
            }

        // Method yang mengembalikan nilai playerTurn tanpa mengubah giliran
            public int NotChangeTurn(int numberOfPlayers, int currentPlayerTurn)
            {
                if (currentPlayerTurn == numberOfPlayers)
                {
                    currentPlayerTurn = 1;
                }
                return currentPlayerTurn;
            }



    }
}

