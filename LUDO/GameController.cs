
using System;
using System.Drawing;
using System.Numerics;
namespace Iqbal
{
	

    public class GameController 
    {

        private Dice dice;
        public Dice Dice => dice;
        // old

        private IBoard board;
        private GameState state;
        private int delay = 500; // Output delay
        private int numberOfPlayers;
        private Player[] players;
        private int playerTurn = 1;
        private Piece[] pieces = new Piece[16];
        int pieceNumber1 = 1;
        int pieceNumber2 = 2;
        int pieceNumber3 = 3;
        int pieceNumber4 = 4;


        Player player = new Player(numberOfTokens: 3);
        
        Team token = new Team();
        IBoard boards = new Board(15,15);
        IPiece piece = new Piece();
        Player playerss = new Player();


        public Action<string> OnPlayerPos { get; set; }
        public Action<string> OnPieceState { get; set; }

        // Constructor method of Game class, starts a new game

        public GameController(int minDiceValue, int maxDiceValue)
        {
            // Other initialization code

            // Create an instance of Dice with custom min and max values
            this.dice = new Dice(minDiceValue, maxDiceValue);
        }


        public GameController()
        {
            
            //Fills colors in the pieces array
            pieces[0] = new Piece("Red");
            pieces[1] = new Piece("Red");
            pieces[2] = new Piece("Red");
            pieces[3] = new Piece("Red");
            pieces[4] = new Piece("Green");
            pieces[5] = new Piece("Green");
            pieces[6] = new Piece("Green");
            pieces[7] = new Piece("Green");
            pieces[8] = new Piece("Yellow");
            pieces[9] = new Piece("Yellow");
            pieces[10] = new Piece("Yellow");
            pieces[11] = new Piece("Yellow");
            pieces[12] = new Piece("Blue");
            pieces[13] = new Piece("Blue");
            pieces[14] = new Piece("Blue");
            pieces[15] = new Piece("Blue");

            
            
            this.state = GameState.InPlay;
            TakeTurns();
            
        }

   

        
        private void TakeTurns(){

            while(this.state == GameState.InPlay){
                

                Player myTurn = players[(playerTurn-1)];
                int playerNumber = myTurn.GetPlayerId();
                SetMessage(myTurn.GetName + "'giliran", delay);
                WriteLine("Dia " + myTurn.GetDescription() + " sebaiknya");
				do
				{
                    Write("Siap untuk (K)aste? ", delay);
				}
				while (Console.ReadKey().KeyChar != 'k');
                WriteLine("Lemparan Dadu:" + dice.ThrowDice().ToString(), delay);
                WriteLine("", delay);
                int diceResult = dice.GetValue();
             
                this.OnPlayerPos = (pos) => Console.WriteLine(pos);
                this.OnPieceState = (state) => Console.WriteLine(state);
                this.HandlePlayerPos("Player", diceResult);
                this.HandlePieceState("Piece", diceResult);
                boards.Display();
                ShowTurnOptions(myTurn.GetTokens());
                
                break;
            }

        }

        public void ShowTurnOptions(Team[] tokens)
		{
            //Int rounds counts how many game rounds there have been
            int rounds = 0;
            
            Player myTurn = players[(playerTurn - 1)];
            int diceResult = dice.GetValue();
            
            int playerNumber = myTurn.GetPlayerId(); // Assuming 4 players
            Type type = myTurn.GetType();

            int row;
            int col;

        

            

            // No options, change turn
            if (diceResult != 6)
            {
                while (!winner())
                {

                    if (this.players.Length == 2 )
                    {
                        // Replace with the actual color you have

                        Console.WriteLine("Choose a color:");
                        Console.WriteLine("1. Red");
                        Console.WriteLine("2. Blue");
                        

                        string userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "1":
                                rounds++;
                                piece.InitializePiece(playerNumber, pieceNumber1);
                                doPlayer("Red", rounds);
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "2":
                                rounds++;
                                doPlayer("Blue", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber2);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "3":
                                rounds++;
                                doPlayer("Green", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber3);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "4":
                                rounds++;
                                doPlayer("Yellow", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber4);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                        }
                    }
                    else
                    {
                        if (this.players.Length == 4)
                        {
                            Console.WriteLine("Player length is 2 or 4 is in the collection.");
                        }
                        else
                        {
                            Console.WriteLine("Player length is not 2, and 4 is not in the collection.");
                        }

                        // Replace with the actual color you have

                        Console.WriteLine("Choose a color:");
                        Console.WriteLine("1. Red");
                        Console.WriteLine("2. Blue");
                        Console.WriteLine("3. Green");
                        Console.WriteLine("4. Yellow");

                        string userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "1":
                                rounds++;
                                doPlayer("Red", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber1);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "2":
                                rounds++;
                                doPlayer("Blue", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber2);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "3":
                                rounds++;
                                doPlayer("Green", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber3);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                            case "4":
                                rounds++;
                                doPlayer("Yellow", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber4);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.ChangeTurn();
                                break;
                        }
                    }

                }
                //Tells the game is over
                GameOver();
               
            }
            else
            {
               //The while loop that stops when a winner has been found, this is where the game runs

                while (!winner())
                {
                    if (this.players.Length == 2)
                    {
                        // Replace with the actual color you have

                        Console.WriteLine("Choose a color:");
                        Console.WriteLine("1. Red");
                        Console.WriteLine("2. Blue");
                       

                        string userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "1":
                                rounds++;
                                doPlayer("Red", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber1);
                                
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");
                                
                                // Get row
                                
                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column
                                
                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row
                                
                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column
                                
                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);
                               
                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "2":
                                rounds++;
                                doPlayer("Blue", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber2);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "3":
                                rounds++;
                                doPlayer("Green", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber3);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "4":
                                rounds++;
                                doPlayer("Yellow", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber4);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                        }
                    }
                    else
                    {
                        // Replace with the actual color you have

                        Console.WriteLine("Choose a color:");
                        Console.WriteLine("1. Red");
                        Console.WriteLine("2. Blue");
                        Console.WriteLine("3. Green");
                        Console.WriteLine("4. Yellow");

                        string userInput = Console.ReadLine();

                        switch (userInput)
                        {
                            case "1":
                                rounds++;
                                piece.InitializePiece(playerNumber, pieceNumber1);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "2":
                                rounds++;
                                doPlayer("Blue", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber2);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "3":
                                rounds++;
                                doPlayer("Green", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber3);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                            case "4":
                                rounds++;
                                doPlayer("Yellow", rounds);
                                piece.InitializePiece(playerNumber, pieceNumber4);

                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.Display();
                                Console.WriteLine();
                                // Melakukan pergerakan sejauh 26 langkah

                                Console.WriteLine($"Set piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the SetPieceAtPosition method

                                boards.SetPieceAtPosition(piece, row, col);

                                // Remove piece at position

                                Console.WriteLine($"Remove piece ");

                                // Get row

                                while (true)
                                {
                                    Console.Write("Enter row: ");
                                    if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row < boards.Rows)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Rows - 1}.");
                                    }
                                }

                                // Get column

                                while (true)
                                {
                                    Console.Write("Enter column: ");
                                    if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col < boards.Columns)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid input. Please enter a number between 0 and {boards.Columns - 1}.");
                                    }
                                }

                                // Call the RemovePiece method

                                boards.RemovePiece(piece, row, col);
                                boards.MovePieceFromHome(piece);
                                boards.GetMoveHistory(piece);

                                // Menampilkan papan Ludo setelah pergerakan
                                Console.WriteLine("Setelah Pergerakan:");
                                boards.Display();
                                this.NotChangeTurn();
                                break;
                        }
                    }
                }

                //Tells the game is over
                GameOver();
                
            }
		}
		
        private void ChangeTurn()
		{
            WriteLine("", 1000);
            if (playerTurn == numberOfPlayers){
                playerTurn = 1;
            } else {
                playerTurn++;
            }

            Write("Shift diputar di: ", 1000);
			for (int i = 3; i > 0; i--)
			{
                Write(" "+i.ToString()+" ", 1000);
			}

            pause(1000);
            TakeTurns();
	    }
        private void NotChangeTurn()
        {
            WriteLine("", 1000);
            if (playerTurn == numberOfPlayers)
            {
                playerTurn = 1;
            }

            Write("Shift diputar di: ", 1000);
            for (int i = 3; i > 0; i--)
            {
                Write(" " + i.ToString() + " ", 1000);
            }

            pause(1000);
            TakeTurns();
        }
        // tambahan baru
        public void doPlayer(string colour, int rounds)
        {
            //Reads whether a key is pressed
            

            //dice kast
            int tk = dice.GetValue();

            //Prints how many rounds have been played, what color moved and what number the dice hit           
            WriteLine($"Round {rounds} Move colour {colour} dice: {tk}  ");

            //Bool which defaults to false
            bool flowOut = false;

            //Checks if you have rolled a 6
            if (tk == 6)
            {

                //Checks what color has hit and then uses the method to check whether a checker should be thrown in "Ingame"
                if (colour == "Red")
                {
                    flowOut = this.putRedInGame();
                }
                if (colour == "Green")
                {
                    flowOut = this.putGreenInGame();
                }
                if (colour == "Yellow")
                {
                    flowOut = this.putYellowInGame();
                }
                if (colour == "Blue")
                {
                    flowOut = this.putBlueInGame();
                }
            }

            //Checks if floatout is still false
            if (!flowOut)
            {
                //
                if (!this.movePieces(tk, colour))
                {
                    WriteLine($"Could neither move " + colour + " piece or set in game!");
                }
            }
            this.status(colour);
        }

        //Method that prints the chip's status
        public void status(string colour)
        {
            if (colour == "Red")
            {
                this.piecesStatusRed();
            }
            if (colour == "Green")
            {
                this.piecesStatusGreen();
            }
            if (colour == "Yellow")
            {
                this.piecesStatusYellow();
            }
            if (colour == "Blue")
            {
                this.piecesStatusBlue();
            }
        }

        //Method that sets the status to red
        public void piecesStatusRed()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteLine("Status on red");
            for (int n = 0; n < 4; n++)
            {
                WriteLine(this.pieces[n].ToString());
            }
            Console.ResetColor();
            WriteLine();
        }

        //Method that sets the status to green
        public void piecesStatusGreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteLine("Status on green");
            for (int n = 4; n < 8; n++)
            {
                WriteLine(this.pieces[n].ToString());
            }
            Console.ResetColor();
            WriteLine();
        }

        //Method that sets the status to yellow
        public void piecesStatusYellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteLine("Status on yellow");
            for (int n = 8; n < 12; n++)
            {
                WriteLine(this.pieces[n].ToString());
            }
            Console.ResetColor();
            WriteLine();
        }

        //Method that sets the status to blue
        public void piecesStatusBlue()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine("Status on blue");
            for (int n = 12; n < 16; n++)
            {
                WriteLine(this.pieces[n].ToString());
            }
            Console.ResetColor();
            WriteLine();
        }

        //Method that receives the dice throw and the color of the player whose turn it is, the method then checks if there are any pieces in the position, and then moves the piece
        public bool movePieces(int eyes, string colour)
        {
            //Process with number of pieces
            for (int i = 0; i < 16; i++)
            {
                //Checks if the piece's state is "Ingame" and if the color is equal to this color
                if (pieces[i].GetCondition() == "Ingame" && this.pieces[i].Color == colour)
                {
                    //Checks if the chipkerOnPos method returns 0     
                    if (this.piecesOnPos(this.pieces[i].Position + eyes) == 0)
                    {
                        //Prints what the dice hit, moves the piece and returns true
                        WriteLine($"Moves piece: {eyes}");
                        this.pieces[i].Move(eyes);
                        return true;
                    }
                    //Checks if the method chipsOnPos returns something that is not equal to 0
                    else if (this.piecesOnPos(this.pieces[i].Position + eyes) != 0)
                    {
                        //Int nextPos is equal to the piece's position + dicee hit
                        int nextPos = this.pieces[i].Position + eyes;

                        //Foorloop with all the pieces
                        for (int n = 0; n < 16; n++)
                        {
                            //Checks if there is a checker in the near position, that the checker's color is not the same as the player's color and if the checker is ingame
                            if (this.pieces[n].Position == nextPos && this.pieces[n].Color != colour && this.pieces[n].Condition == "Ingame")
                            {
                                //Sets the pieces to state "Home", resets the current position and prints the color of the piece and "Return to start"
                                this.pieces[n].SetCondition("Home");
                                this.pieces[n].Position = this.pieces[n].StartPosition;
                                WriteLine(this.pieces[n].Color + " Return to start");
                                return true;
                            }
                        }
                        //Moves the chip and prints
                        this.pieces[i].Move(eyes);
                        WriteLine($"Moves piece: {eyes}");
                        return true;
                    }
                    else
                    {
                        //Moves the rbicken
                        this.pieces[i].Move(eyes);
                        return true;
                    }
                }

                //Checks if the piece is in "Endgame" and moves it
                if (pieces[i].GetCondition() == "Endgame")
                {
                    this.pieces[i].Move(eyes);
                    return true;
                }
            }
            return false;
        }

        //Method that checks if red has any pieces in "Home" otherwise it sets the state to "Ingame" and returns true
        public bool putRedInGame()
        {
            for (int i = 0; i < 4; i++)
            {
                if (this.pieces[i].GetCondition() == "Home")
                {
                    WriteLine("Puts red in the game!");
                    this.pieces[i].SetCondition("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Method that checks if green has any pieces in "Home" otherwise it sets the state to "Ingame" and returns true
        public bool putGreenInGame()
        {
            for (int i = 4; i < 8; i++)
            {
                if (this.pieces[i].GetCondition() == "Home")
                {
                    WriteLine("Puts Green in the game!");
                    this.pieces[i].SetCondition("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Method that checks if yellow has any pieces in "Home" otherwise it sets the state to "Ingame" and returns true
        public bool putYellowInGame()
        {
            for (int i = 8; i < 12; i++)
            {
                if (this.pieces[i].GetCondition() == "Home")
                {
                    WriteLine("Puts Yellow in the game!");
                    this.pieces[i].SetCondition("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Method that checks if blue has any pieces in "Home" otherwise it sets the state to "Ingame" and returns true
        public bool putBlueInGame()
        {
            for (int i = 12; i < 16; i++)
            {
                if (this.pieces[i].GetCondition() == "Home")
                {
                    WriteLine("Puts Blue in the game!");
                    this.pieces[i].SetCondition("Ingame");
                    return true;
                }
            }
            return false;
        }

        //Checks if there are any pieces on the next position you are about to move to and if those pieces are "Ingame"
        public int piecesOnPos(int pos)
        {
            int antalpieces = 0;
            foreach (Piece p in this.pieces)
            {
                if (p.Position % 57 == pos && p.Condition == "Ingame")
                    antalpieces++;
            }
            return antalpieces;
        }

        //Method that checks if all pieces in a certain color are in "Goal" mode and returns true if a color has all pieces in the goal otherwise returns false
        public bool winner()
        {
            int red = 0;
            for (int n = 0; n < 4; n++)
            {
                if (this.pieces[n].GetCondition() == "Goal")
                {
                    red++;
                }
                if (red == 4)
                {
                    WriteLine("Red wins");
                    return true;
                }
            }
            int green = 0;
            for (int n = 4; n < 8; n++)
            {
                if (this.pieces[n].GetCondition() == "Goal")
                {
                    green++;
                }
                if (green == 4)
                {
                    WriteLine("Green wins");
                    return true;
                }
            }
            int yellow = 0;
            for (int n = 8; n < 12; n++)
            {
                if (this.pieces[n].GetCondition() == "Goal")
                {
                    yellow++;
                }
                if (yellow == 4)
                {
                    WriteLine("Yellow wins");
                    return true;
                }
            }
            int blue = 0;
            for (int n = 12; n < 16; n++)
            {
                if (this.pieces[n].GetCondition() == "Goal")
                {
                    blue++;
                }
                if (blue == 4)
                {
                    WriteLine("Blue wins");
                    return true;
                }
            }
            return false;
        }

        void GameOver()
        {
            

            Console.WriteLine("Game Over!");
        

            
        }

        public virtual void HandlePlayerPos(string message, int diceResult)
        {
            if (diceResult == 6)
            {
                OnPlayerPos?.Invoke($"Posisi Berubah: {message}");
            }
            else
            {
                OnPlayerPos?.Invoke($"Posisi Tidak Berubah Berubah Jika Belum Ada yang Keluar dari Home: {message}");
            }
        }

        public virtual void HandlePieceState(string message, int diceResult)
        {
            if (diceResult == 6)
            {
                OnPieceState?.Invoke($"Kondisi Piece Keluar Kandang: {message}");
            }
            else
            {
                OnPieceState?.Invoke($"Kondisi Piece Tetap Kecuali Jika Ada Yang Ada Di Luar Home: {message}");
            }
        }


    }


}

