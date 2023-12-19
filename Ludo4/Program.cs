using System;
using System.Threading;
using System.Threading.Tasks;
using LudoLib;

class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to Ludo!");

            // Set the desired min and max values for the dice
            int minDiceValue = 1;
            int maxDiceValue = 6;

            // Prompt the user for the number of players
            int numberOfPlayers;
            do
            {
                Console.Write("Enter the number of players (2 or 4): ");
            } while (!int.TryParse(Console.ReadLine(), out numberOfPlayers) || (numberOfPlayers != 2 && numberOfPlayers != 4));

            // Create an instance of LudoGameController with custom min and max values for the dice
            IBoard board = new Board(boardSize: 20);
            GameController ludoGameController = new GameController(minDiceValue, maxDiceValue, board);
           

            // Add players to the LudoGameController based on the user's choice
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                Console.Write($"Enter the name for Player {i}: ");
                string playerName = Console.ReadLine();
                Colors playerColor = (Colors)i; // Assuming the Colors enum values correspond to player numbers
                ludoGameController.AddPlayer(i, playerName, playerColor);
            }

            // Access the Dice instance through the LudoGameController
            Dice dice = ludoGameController.Dice;

            // Access the list of players through the LudoGameController
            List<IPlayer> players = ludoGameController.Players;

            // Use the dice and players in the LudoGameController or any other part of your program
            // Use the dice and players in the LudoGameController or any other part of your program
            foreach (IPlayer player in ludoGameController.Players)
            {
                Console.WriteLine($"Player Name: {player.Name}, Color: {player.Color}");

                // Access the player's pieces
                foreach (Piece piece in player.Pieces)
                {
                    // Do something with each piece
                    Console.WriteLine($"  Piece Color: {piece.GetColor()}, Piece State: {piece.GetState()}");
                }
            }


         
            // ... rest of your code
        }
    }

    



