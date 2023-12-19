using System;
using System.Collections.Generic;
using System.Threading;

namespace LudoLib
{  
        public class GameController
        {
            private Dice _dice;
            private List<IPlayer> _players;

            private IBoard _board; // Add a private field for the board

            public GameController(int minDiceValue, int maxDiceValue, IBoard board)
            {
                _dice = new Dice(minDiceValue, maxDiceValue);
                _players = new List<IPlayer>();
                _board = board; // Inject the board instance

                
                _board.SetSafeSquares(); // Set safe squares on the board
            }

            // Method to add a player to the list of players
            public void AddPlayer(int id, string name, Colors color)
            {
                IPlayer player = new Player(id, name, color);
                _players.Add(player);
            }

            // Property to access the Dice instance
            public Dice Dice => _dice;

            // Property to access the list of players
            public List<IPlayer> Players => _players;

            // Property to access the board
             public IBoard Board => _board;

            // ... rest of your LudoGameController code
        }
    }

