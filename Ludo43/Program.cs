using System;
using System.Numerics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Ludo4;
using LudoLib;
using NLog;


class Program
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    static async Task Main(string[] args)
    {
        // Initialize NLog
        LogManager.LoadConfiguration("NLog.config");

        try
        {
            // Log a message when the program starts
            Logger.Info("Ludo game started at {DateTime.Now}");

            // Your game initialization and logic here
            Game game = new Game();

            // Example log messages
            Logger.Info("Ludo game started successfully");
            Logger.Info("Ludo game finished with sukses!");

            // ... rest of your code
        }
        catch (Exception ex)
        {
            // Log any unhandled exceptions
            Logger.Error(ex, "An unexpected error occurred.");
        }
        finally
        {
            // Ensure to flush and shut down the NLog logging system properly
            LogManager.Shutdown();
        }
    }





    class Game
    {
        private GameState state;
     
        private int delay = 1000; // Output delay
        private int numberOfPlayers;
        private int playerTurn = 1;
        private Player[] players;
        IPiece piece = new Piece();
        IBoard boards = new Board(15, 15);

        PieceNumber piece1 = PieceNumber.Piece1;
        PieceNumber piece2 = PieceNumber.Piece2;
        PieceNumber piece3 = PieceNumber.Piece3;
        PieceNumber piece4 = PieceNumber.Piece4;

        static int diceMaxValue = 6;
        static int diceMinValue = 1;

        Dice dice = new Dice(diceMinValue, diceMaxValue);
        GameController gameController = new GameController();
        public Game()
        {
            //Fills colors in the pieces array
            gameController.pieces[0] = new Piece("Red");
            gameController.pieces[1] = new Piece("Red");
            gameController.pieces[2] = new Piece("Red");
            gameController.pieces[3] = new Piece("Red");
            gameController.pieces[4] = new Piece("Green");
            gameController.pieces[5] = new Piece("Green");
            gameController.pieces[6] = new Piece("Green");
            gameController.pieces[7] = new Piece("Green");
            gameController.pieces[8] = new Piece("Yellow");
            gameController.pieces[9] = new Piece("Yellow");
            gameController.pieces[10] = new Piece("Yellow");
            gameController.pieces[11] = new Piece("Yellow");
            gameController.pieces[12] = new Piece("Blue");
            gameController.pieces[13] = new Piece("Blue");
            gameController.pieces[14] = new Piece("Blue");
            gameController.pieces[15] = new Piece("Blue");


            SetMessage("Selamat datang di Ludo", delay);
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();

            this.state = GameState.InPlay;
            TakeTurns();


        }

        public async Task StarGame()
        {


        }

        private async Task WriteLine(string txt = "", int dl = 0)
        {
            await Task.Delay(dl);
            Console.WriteLine(txt);
        }

        private async Task WriteCenterLine(string txt = "", int dl = 0)
        {
            string textToEnter = txt;
            await Task.Delay(dl);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }

        private async Task Write(string txt, int dl = 0)
        {
            await Task.Delay(dl);
            Console.Write(txt);
        }

        private void Clear()
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------").Wait();
            Console.WriteLine();
        }

        // Make MainMenu
        private void SetMessage(string message, int dl = 0)
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------").Wait();
            WriteCenterLine(message, dl).Wait();
            Console.WriteLine();
        }

        private async Task PauseAsync(int dl)
        {
            await Task.Delay(dl);
        }

        private void SetNumberOfPlayers()
        {
            Write("Berapa banyak pemain?: ", delay);

            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers))
                {
                    WriteLine();
                    Write("Nilai tidak valid, pilih angka antara 2 dan 4: ", delay);
                }
            }
            WriteLine("", 1000);
            Task.Delay(2000).Wait();
        }

        private void CreatePlayers()
        {
            SetMessage("Masukkan nama");
            this.players = new Player[this.numberOfPlayers];

            for (int i = 0; i < this.numberOfPlayers; i++)
            {
                Write("Siapa nama pemainnya #" + (i + 1) + ": ", delay);
                string name = Console.ReadLine();

                Team[] tkns = AssingTokens(i);

                players[i] = new Player((i + 1), name, tkns);
            }
        }

        private Team[] AssingTokens(int colorIndex)
        {

            Team[] tokens = new Team[4];

            for (int i = 0; i <= 3; i++)
            {
                switch (colorIndex)
                {
                    case 0:
                        tokens[i] = new Team((i + 1), GameColor.Red);
                        break;
                    case 1:
                        tokens[i] = new Team((i + 1), GameColor.Blue);
                        break;
                    case 2:
                        tokens[i] = new Team((i + 1), GameColor.Green);
                        break;
                    case 3:
                        tokens[i] = new Team((i + 1), GameColor.Yellow);
                        break;
                }
            }
            return tokens;
        }


        private void ShowPlayers()
        {
            SetMessage("Oke, inilah pemain Anda:", delay);

            foreach (Player pl in this.players)
            {
                WriteLine(pl.GetDescription(), 1000);
            }
            Task.Delay(2000).Wait();

            WriteLine("", 0);
        }

        private void TakeTurns()
        {

            while (this.state == GameState.InPlay)
            {


                Player myTurn = players[(playerTurn - 1)];
                int playerNumber = myTurn.GetPlayerId();
                SetMessage(myTurn.GetName + "'giliran", delay);
                WriteLine("Dia " + myTurn.GetDescription() + " sebaiknya");
                do
                {
                    Write("Siap untuk (K)aste? ", delay);
                }
                while (Console.ReadKey().KeyChar != 'k');
                int diceResult = dice.ThrowDice();
                WriteLine("Lemparan Dadu:" + diceResult.ToString(), delay);
                
                Task.Delay(2000).Wait();
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
                while (!gameController.Winner())
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
                                piece.InitializePiece(playerNumber, (int)piece1);
                                Console.WriteLine(gameController.DoPlayer("Red", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "2":
                                rounds++;
                                
                                piece.InitializePiece(playerNumber, (int)piece2);
                                Console.WriteLine(gameController.DoPlayer("Blue", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "3":
                                rounds++;
                                Console.WriteLine();
                                piece.InitializePiece(playerNumber, (int)piece3);
                                Console.WriteLine(gameController.DoPlayer("Green", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "4":
                                rounds++;
                                gameController.DoPlayer("Yellow", rounds, diceResult);
                                piece.InitializePiece(playerNumber, (int)piece4);
                                Console.WriteLine(gameController.DoPlayer("Yellow", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
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
                                Console.WriteLine();
                                piece.InitializePiece(playerNumber, (int)piece1);
                                Console.WriteLine(gameController.DoPlayer("Red", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "2":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece2);
                                Console.WriteLine(gameController.DoPlayer("Blue", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "3":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece3);
                                Console.WriteLine(gameController.DoPlayer("Green", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
                                break;
                            case "4":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece4);
                                Console.WriteLine(gameController.DoPlayer("Yellow", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.AddTurn();
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
                
                while (!gameController.Winner())
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
                                Console.WriteLine();
                                piece.InitializePiece(playerNumber, (int)piece1);
                                Console.WriteLine(gameController.DoPlayer("Red", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "2":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece2);
                                Console.WriteLine(gameController.DoPlayer("Blue", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "3":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece3);
                                Console.WriteLine(gameController.DoPlayer("Green", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "4":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece4);
                                Console.WriteLine(gameController.DoPlayer("Yellow", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
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
                                piece.InitializePiece(playerNumber, (int)piece1);
                                Console.WriteLine(gameController.DoPlayer("Red", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "2":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece2);
                                Console.WriteLine(gameController.DoPlayer("Blue", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "3":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece3);
                                Console.WriteLine(gameController.DoPlayer("Green", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                            case "4":
                                rounds++;
                                piece.InitializePiece(playerNumber, (int)piece4);
                                Console.WriteLine(gameController.DoPlayer("Yellow", rounds, diceResult));
                                // Menampilkan papan Ludo sebelum pergerakan
                                Console.WriteLine("Sebelum Pergerakan:");
                                boards.GetBoardAsString();
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
                                boards.GetBoardAsString();
                                this.NotAddTurn();
                                break;
                        }
                    }
                }

                //Tells the game is over
                GameOver();

            }
        }

        private void AddTurn()
        {
            WriteLine("", 1000);
            if (playerTurn == numberOfPlayers)
            {
                playerTurn = 1;
            }
            else
            {
                playerTurn++;
            }

            Write("Shift diputar di: ", 1000);
            for (int i = 3; i > 0; i--)
            {
                Write(" " + i.ToString() + " ", 1000);
            }
            Task.Delay(4000).Wait();

            TakeTurns();
        }
        private void NotAddTurn()
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
            Task.Delay(4000).Wait();

            TakeTurns();
        }

        void GameOver()
        {


            Console.WriteLine("Game Over!");

            gameController.Cleanup();

        }
    }
}
