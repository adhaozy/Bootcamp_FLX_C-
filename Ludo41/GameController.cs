using Ludo4;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LudoLib
{
            /// <summary>
            /// Represents the game controller for a Ludo game.
            /// </summary>
            public class GameController
            {
                private int currentPlayer;
                private Dice? _dice;
                private List<IPlayer>? _players;
             
                private IPlayer _player;
                public Piece[] pieces = new Piece[16];
                //private int playerTurn = 1;
                //private IBoard _board; // Add a private field for the board
                public GameModes GameModes { get; private set; }
                Dice dice = new Dice();
                private Dictionary<IPlayer, Dictionary<Piece, StateOfPiece>> _pieceStates;


                /// <summary>
                /// Initializes a new instance of the <see cref="GameController"/> class.
                /// </summary>
                public GameController()
                {
                    

                    _dice = new Dice();
                    _players = new List<IPlayer>();
                    //_board = board;
                    _pieceStates = new Dictionary<IPlayer, Dictionary<Piece, StateOfPiece>>();
                    currentPlayer = 1;

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

            
                /// <summary>
                /// Performs a player's turn based on the dice roll and player's color.
                /// </summary>
                /// <param name="colour">The color of the player.</param>
                /// <param name="rounds">The current round number.</param>
                /// <returns>A string containing the result of the player's turn.</returns>
                public string DoPlayer(string colour, int rounds, int dice)
                {
                    //Reads whether a key is pressed
                    Console.WriteLine(_dice.GetValue());
                    //dice kast
                    int tk = dice;

                    // String to store the result message
                    StringBuilder resultMessage = new StringBuilder();

                    //Prints how many rounds have been played, what color moved, and what number the dice hit           
                    resultMessage.AppendLine($"Round {rounds} Move colour {colour} dice: {tk}");

                    //Bool which defaults to false
                    bool flowOut = false;

                    //Checks if you have rolled a 6
                    if (tk == 6)
                    {
                        //Checks what color has hit and then uses the method to check whether a checker should be thrown in "Ingame"
                        switch (colour)
                        {
                            case "Red":
                                flowOut = PutPieceInGame("Red");
                                break;
                            case "Green":
                                flowOut = PutPieceInGame("Green");
                                break;
                            case "Yellow":
                                flowOut = PutPieceInGame("Yellow");
                                break;
                            case "Blue":
                                flowOut = PutPieceInGame("Blue");
                                break;
                        }
                    }

                    //Checks if floatout is still false
                    if (!flowOut)
                    {
                        if (!MovePieces(tk, colour))
                        {
                            resultMessage.AppendLine($"Could neither move {colour} piece or set in game!");
                        }
                    }

                    resultMessage.AppendLine(Status(colour));

                    // Returning the result message as a string
                    return resultMessage.ToString();
                }

                /// <summary>
                /// Gets the current status of pieces for a specific color.
                /// </summary>
                /// <param name="colour">The color of the player.</param>
                /// <returns>A string containing the status of pieces for the specified color.</returns>
                public string Status(string colour)
                {
                    StringBuilder statusMessage = new StringBuilder();

                    if (colour == "Red")
                    {
                        statusMessage.AppendLine(PiecesStatus("Red"));
                    }
                    if (colour == "Green")
                    {
                        statusMessage.AppendLine(PiecesStatus("Green"));
                    }
                    if (colour == "Yellow")
                    {
                        statusMessage.AppendLine(PiecesStatus("Yellow"));
                    }
                    if (colour == "Blue")
                    {
                        statusMessage.AppendLine(PiecesStatus("Blue"));
                    }

                    return statusMessage.ToString();
                }

                /// <summary>
                /// Retrieves the status of pieces for the specified color.
                /// </summary>
                /// <param name="color">The color of the pieces.</param>
                /// <returns>A string containing the status of pieces for the specified color.</returns>
                public string PiecesStatus(string color)
                {
                    StringBuilder status = new StringBuilder();
                    status.AppendLine($"Status on {color.ToLower()}");

                    int startIndex, endIndex;

                    // Determine the start and end indices based on the color
                    switch (color)
                    {
                        case "Red":
                            startIndex = 0;
                            endIndex = 3;
                            break;
                        case "Green":
                            startIndex = 4;
                            endIndex = 7;
                            break;
                        case "Yellow":
                            startIndex = 8;
                            endIndex = 11;
                            break;
                        case "Blue":
                            startIndex = 12;
                            endIndex = 15;
                            break;
                        default:
                            return $"Invalid color: {color}";
                    }

                    // Iterate over the pieces within the specified range
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        status.AppendLine(pieces[i].ToString());
                    }

                    return status.ToString();
                }


                /// <summary>
                /// Moves pieces of the specified color based on the given dice roll.
                /// </summary>
                /// <param name="eyes">The number rolled on the dice.</param>
                /// <param name="colour">The color of the pieces to be moved.</param>
                /// <returns>True if the pieces are successfully moved; otherwise, false.</returns>
                public bool MovePieces(int eyes, string colour)
                {
                    //Process with number of pieces
                    for (int i = 0; i < 16; i++)
                    {
                        //Checks if the piece's state is "Ingame" and if the color is equal to this color
                        if (pieces[i].GetCondition() == "Ingame" && pieces[i].Color == colour)
                        {
                            //Checks if the PieceOnPos method returns 0     
                            if (PieceOnPos(pieces[i].Position + eyes) == 0)
                            {
                                //Moves the piece
                                pieces[i].Move(eyes);
                                return true;
                            }
                            //Checks if the method PieceOnPos returns something that is not equal to 0
                            else if (PieceOnPos(pieces[i].Position + eyes) != 0)
                            {
                                //Int nextPos is equal to the piece's position + dice hit
                                int nextPos = pieces[i].Position + eyes;

                                //Loop through all the pieces
                                for (int n = 0; n < 16; n++)
                                {
                                    //Checks if there is a checker in the nearby position, that the checker's color is not the same as the player's color and if the checker is ingame
                                    if (pieces[n].Position == nextPos && pieces[n].Color != colour && pieces[n].Condition == "Ingame")
                                    {
                                        //Sets the piece to state "Home", resets the current position
                                        pieces[n].SetCondition("Home");
                                        pieces[n].Position = pieces[n].StartPosition;
                                        return true;
                                    }
                                }
                                //Moves the piece
                                pieces[i].Move(eyes);
                                return true;
                            }
                            else
                            {
                                //Moves the piece
                                pieces[i].Move(eyes);
                                return true;
                            }
                        }

                        //Checks if the piece is in "Endgame" and moves it
                        if (pieces[i].GetCondition() == "Endgame")
                        {
                            pieces[i].Move(eyes);
                            return true;
                        }
                    }
                    return false;
                }

                /// <summary>
                /// Puts a piece of the specified color in the "Ingame" state.
                /// </summary>
                /// <param name="color">The color of the pieces to put in "Ingame" state.</param>
                /// <returns>True if a piece of the specified color is successfully put in "Ingame" state; otherwise, false.</returns>
                public bool PutPieceInGame(string color)
                {
                    int startIndex, endIndex;

                    // Determine the start and end indices based on the color
                    switch (color)
                    {
                        case "Red":
                            startIndex = 0;
                            endIndex = 3;
                            break;
                        case "Green":
                            startIndex = 4;
                            endIndex = 7;
                            break;
                        case "Yellow":
                            startIndex = 8;
                            endIndex = 11;
                            break;
                        case "Blue":
                            startIndex = 12;
                            endIndex = 15;
                            break;
                        default:
                            return false; // Invalid color
                    }

                    // Iterate over the pieces within the specified range
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        if (pieces[i].GetCondition() == "Home")
                        {
                            pieces[i].SetCondition("Ingame");
                            return true;
                        }
                    }

                    return false; // No pieces in "Home" for the specified color
                }



                /// <summary>
                /// Checks if there are any pieces on the next position and if those pieces are "Ingame".
                /// </summary>
                /// <param name="pos">The position to check.</param>
                /// <returns>The number of pieces on the specified position that are "Ingame".</returns>
                public int PieceOnPos(int pos)
                {
                    int antalpieces = 0;
                    foreach (Piece p in this.pieces)
                    {
                        if (p.Position % 57 == pos && p.Condition == "Ingame")
                            antalpieces++;
                    }
                    return antalpieces;
                }

                /// <summary>
                /// Checks if a player has all pieces in the "Goal" state, indicating a winner.
                /// </summary>
                /// <returns>True if a player has all pieces in the "Goal" state; otherwise, false.</returns>
                public bool Winner()
                {
                    string[] colors = { "Red", "Green", "Yellow", "Blue" };

                    foreach (var color in colors)
                    {
                        int count = 0;

                        for (int n = 0; n < pieces.Length; n++)
                        {
                            // Assuming GetColor() returns a GameColor enum
                            if (pieces[n].GetCondition() == "Goal" && pieces[n].GetColor().ToString() == color)
                            {
                                count++;
                            }

                            if (count == 4)
                            {
                                return true; // Color wins
                            }
                        }
                    }

                    return false; // No winner yet
                }





                // public virtual void HandlePlayerPos(string message, int diceResult)
                // {
                //     if (diceResult == 6)
                //     {
                //         OnPlayerPos?.Invoke($"Posisi Berubah: {message}");
                //     }
                //     else
                //     {
                //         OnPlayerPos?.Invoke($"Posisi Tidak Berubah Berubah Jika Belum Ada yang Keluar dari Home: {message}");
                //     }
                // }

                // public virtual void HandlePieceState(string message, int diceResult)
                // {
                //     if (diceResult == 6)
                //     {
                //         OnPieceState?.Invoke($"Kondisi Piece Keluar Kandang: {message}");
                //     }
                //     else
                //     {
                //         OnPieceState?.Invoke($"Kondisi Piece Tetap Kecuali Jika Ada Yang Ada Di Luar Home: {message}");
                //     }
                // }



                public string ShowTurn()
                {
                    // Create a StringBuilder to build the output
                    StringBuilder output = new StringBuilder();
                    output.AppendLine("Current Game State:");

                    foreach (IPlayer player in Players)
                    {
                        output.AppendLine($"Player Name: {player.Name}, Color: {player.GetColor}");

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

                /// <summary>
                /// Changes the turn based on the dice result.
                /// </summary>
                /// <param name="diceResult">The result of the dice roll.</param>
                /// <returns>True if the player gets an extra turn; otherwise, false.</returns>

                public bool ChangeTurn(int diceResult)
                {
                    // Mengubah giliran sesuai dengan parameter yang diberikan
                    if (diceResult == _dice.MaxDiceValue)
                    {
                        // Jika mendapat dadu 6, berikan giliran tambahan
                        return true;
                    }
                    else
                    {
                        // Jika tidak mendapat dadu 6, ganti giliran seperti biasa
                        currentPlayer = (currentPlayer % 4) + 1;
                        return false;
                    }
                        }
                /// <summary>
                /// Gets the current player number.
                /// </summary>
                /// <returns>The current player number.</returns>
                public int GetCurrentPlayer()
                {
                    return currentPlayer;
                }


            
            }
}

