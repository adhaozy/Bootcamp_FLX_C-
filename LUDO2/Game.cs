using Iqbal;
using System;
using System.Numerics;
namespace ITD.OOP1.Ludo
{
	// Nice colors of a Ludo game :) 
	public enum GameColor { Kuning, Biru, Merah, Hijau };
    public enum GameState { InPlay, Finished };

    public class Game 
    {
        private readonly IBoard board;

        Player player = new Player(numberOfTokens: 3);

        private GameState state;
        private int delay = 500; // Output delay

        private int numberOfPlayers;
        private Player[] players;
        private int playerTurn = 1;

      

        Token myToken = new Token();

        IBoard ludoBoard = new LudoBoard(10, 10);

        IPiece piece = new Piece();

        private Dice dice = new Dice();
        Token token = new Token();
        // Constructor method of Game class, starts a new game

        public Game(IBoard gameBoard)
        {
            board = gameBoard ?? throw new ArgumentNullException(nameof(gameBoard));
           
        }

        
        public Game()
        {
            SetMessage("Selamat datang di Ludo", delay);
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            this.state = GameState.InPlay;
            TakeTurns();
        }

        private void WriteLine(string txt = "", int dl = 0)
        {
            System.Threading.Thread.Sleep(dl);
            Console.WriteLine(txt);
        }

        private void WriteCenterLine(string txt = "", int dl = 0)
        {
            string textToEnter = txt;
            System.Threading.Thread.Sleep(dl);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }

        private void Write(string txt, int dl = 0)
        {
            System.Threading.Thread.Sleep(dl);
            Console.Write(txt);
        }

        private void Clear()
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------");
            Console.WriteLine();
        }

        // Make MainMenu
        private void SetMessage(string message, int dl = 0)
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------", 0);
            WriteCenterLine(message, dl);
            Console.WriteLine();
        }

        private void pause(int dl){
            System.Threading.Thread.Sleep(dl);
        }

        private void SetNumberOfPlayers()
        {
            Write("Berapa banyak pemain?: ", delay);

            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers)){
                    WriteLine();
                    Write("Nilai tidak valid, pilih angka antara 2 dan 4: ", delay);
                }
            }
            WriteLine("", 1000);
        }

        private void CreatePlayers(){
            SetMessage("Masukkan nama");
            this.players = new Player[this.numberOfPlayers];

            for (int i = 0; i < this.numberOfPlayers; i++){
                Write("Siapa nama pemainnya #" + (i+1) + ": ", delay);
                string name = Console.ReadLine();

                Token[] tkns = AssingTokens(i);

                players[i] = new Player((i+1), name, tkns);
            }
        }

        private Token[] AssingTokens(int colorIndex){

            Token[] tokens = new Token[4];

            for (int i = 0; i <= 3; i++)
            {
                switch (colorIndex)
                {
                    case 0:
                        tokens[i] = new Token((i+1), GameColor.Kuning);
                        break;
                    case 1:
                        tokens[i] = new Token((i + 1), GameColor.Biru);
                        break;
                    case 2:
                        tokens[i] = new Token((i + 1), GameColor.Merah);
                        break;
                    case 3:
                        tokens[i] = new Token((i + 1), GameColor.Hijau);
                        break;
                }
            }
            return tokens;
        }


        private void ShowPlayers(){
            SetMessage("Oke, inilah pemain Anda:", delay);
            foreach(Player pl in this.players){
                WriteLine(pl.GetDescription(), 1000);
            }
            WriteLine("", 2000);
        }


        private void TakeTurns(){

            while(this.state == GameState.InPlay){
                

                Player myTurn = players[(playerTurn-1)];
                SetMessage(myTurn.GetName + "'giliran", delay);
                WriteLine("Dia " + myTurn.GetDescription() + " sebaiknya");
				do
				{
                    Write("Siap untuk (K)aste? ", delay);
				}
				while (Console.ReadKey().KeyChar != 'k');
                WriteLine("Lemparan Dadu:" + dice.ThrowDice().ToString(), delay);
                WriteLine("", delay);
              
                ludoBoard.Display();
                
                ShowTurnOptions(myTurn.GetTokens());
                
                break;
            }

        }

        public void ShowTurnOptions(Token[] tokens)
		{

            int indexToChange1 = 0;
            int indexToChange2 = 1;
            int indexToChange3 = 2;
            int indexToChange4 = 3;
            int choice = 0;
            Console.WriteLine($"Token is ID: {token.GetTokenId()}");
            //object tokenID = null;
            
            WriteLine("Inilah karya Anda:");
			foreach (Token tk in tokens)
			{

                Write("Bagian #" + tk.GetTokenId() + ": ditempatkan: " + tk.GetState(), 1000);

                switch(tk.GetState()){
                    case TokenState.Home:
                        if(dice.GetValue() == 6){

                            Write(" <- Dapat dimainkan", delay);
                            choice++;
                        } else {
                            Write(" <- TIDAK dapat dimainkan", delay);
                        }
                        //tokenID = tk.GetTokenId().ToString();
                       
                        break;
                    case TokenState.InPlay:
                        Write(" <- Dapat dimainkan", delay);
                        choice++;
						break;
                    case TokenState.Safe:
                        Write(" <- Dapat dimainkan", delay);
                        choice++;
						break;
                }
                WriteLine("",  delay);

                

            }
            //return tokenID;

            WriteLine("", delay);
            WriteLine("Kamu punya " + choice.ToString()+ " pilihan dalam perjalanan ini.", 2000);

            // No options, change turn
            if(choice == 0){
                this.ChangeTurn();
            } else {
                WriteLine("Pilih #piece yang ingin Anda mainkan?");
                Console.WriteLine("1. Piece 1");
                Console.WriteLine("2. Piece 2");
                Console.WriteLine("3. Piece 3");
                Console.WriteLine("4. Piece 4");
                Console.WriteLine("5. Exit");


                string userInput;

                do
                {
                    //Write("Bagian #" + tokens.GetTokenId() + ": ditempatkan: " + tokens.GetState(), 1000);
                    Console.Write("Enter your choice (1-4): ");
                    userInput = Console.ReadLine();

                    Player myTurn = players[(playerTurn - 1)];
                    int diceResult = dice.GetValue();
                    int pieceNumber1 = 1;
                    int pieceNumber2 = 2;
                    int pieceNumber3 = 3;
                    int pieceNumber4 = 4;
                    int playerNumber = myTurn.GetPlayerId(); // Assuming 4 players
                    Type type = myTurn.GetType();
                    switch (userInput)
                    {
                        case "1":
                            Console.WriteLine("You chose Option 1.");
                            
                            Console.WriteLine($"Token is ID: {myTurn.GetPlayerId()}");

                            // Check if the index is valid for the first indexToChange
                            if (indexToChange1 >= 0 && indexToChange1 < tokens.Length)
                            {
                                // Set TokenStatus to InPlay for the specified index
                                tokens[indexToChange1].ChangeStatusFromHomeToInPlay();
                            }
                            else
                            {
                                // Handle invalid index, throw exception or log an error
                                throw new ArgumentOutOfRangeException(nameof(indexToChange1), "Invalid index.");
                            }
                            token.MoveToInPlay();
                            Console.WriteLine($"Token is now in state: {token.GetState()}");
                           

                            Console.WriteLine($"Player Length {this.players.Length}");
                            Console.WriteLine($"Token is now in ID: {(playerNumber, pieceNumber1, piece.CurrentPosition)}");
                            Console.WriteLine($"Jumlah Pemain: {this.players.Length}");
                            //Console.WriteLine($"TESTTTTTTTTTTTTT");
                            //string InputPiecePosition1 = Console.ReadLine();
                            //int number = int.Parse(InputPiecePosition1);
                            piece.InitializePiece(playerNumber,pieceNumber1);
                            ludoBoard.SetPieceAtPosition(piece, 0, 0);
                            ludoBoard.Display();
                            //
                            //ludoBoard.MovePieceFromHome(piece);
                            ludoBoard.GetMoveHistory(piece);
                            ludoBoard.RemovePiece(piece);
                            ludoBoard.MovePieceInPlay(piece,5);
                            ludoBoard.SetPieceAtPosition(piece, 0, 5);
                         
                            

                            ludoBoard.Display();
                            //IPiece pieceAtPosition = ludoBoard.GetPieceAtPosition(targetRow, targetCol);

                            

                       
                            this.NotChangeTurn();
                            break;

                        case "2":
                            Console.WriteLine("You chose Option 2.");
                            Console.WriteLine($"Token is ID: {token.GetTokenId()}");

                            /// Check if the index is valid for the second indexToChange
                            if (indexToChange2 >= 0 && indexToChange2 < tokens.Length)
                            {
                                // Set TokenStatus to InPlay for the specified index
                                tokens[indexToChange2].ChangeStatusFromHomeToInPlay();
                            }
                            else
                            {
                                // Handle invalid index, throw exception or log an error
                                throw new ArgumentOutOfRangeException(nameof(indexToChange2), "Invalid index.");
                            }
                            token.MoveToInPlay();
                            Console.WriteLine($"Token is now in state: {token.GetState()}");

                            Console.WriteLine($"Lembar Dadu: {dice.ThrowDice()}");
                           
                           
                            Console.WriteLine($"Token is now in ID: {(playerNumber, diceResult)}");
                            Console.WriteLine($"Jumlah Pemain: {this.players.Length}");
                           
                           
                            //ludoBoard.DisplayBoard();
                            this.NotChangeTurn();
                            break;

                        case "3":
                            Console.WriteLine("You chose Option 3.");
                            Console.WriteLine($"Token is ID: {token.GetTokenId()}");

                            // Check if the index is valid for the second indexToChange
                            if (indexToChange2 >= 0 && indexToChange3 < tokens.Length)
                            {
                                // Set TokenStatus to InPlay for the specified index
                                tokens[indexToChange3].ChangeStatusFromHomeToInPlay();
                            }
                            else
                            {
                                // Handle invalid index, throw exception or log an error
                                throw new ArgumentOutOfRangeException(nameof(indexToChange3), "Invalid index.");
                            }
                            Console.WriteLine($"Token is now in state: {token.GetState()}");

                            Console.WriteLine($"Lembar Dadu: {dice.ThrowDice()}");


                            Console.WriteLine($"Token is now in ID: {(playerNumber, diceResult)}");
                            Console.WriteLine($"Jumlah Pemain: {this.players.Length}");
                            
                            //ludoBoard.DisplayBoard();
                            this.NotChangeTurn();
                            break;

                        case "4":
                            Console.WriteLine("You chose Option 4.");
                            Console.WriteLine($"Token is ID: {token.GetTokenId()}");

                            // Check if the index is valid for the second indexToChange
                            if (indexToChange4 >= 0 && indexToChange4 < tokens.Length)
                            {
                                // Set TokenStatus to InPlay for the specified index
                                tokens[indexToChange4].ChangeStatusFromHomeToInPlay();
                            }
                            else
                            {
                                // Handle invalid index, throw exception or log an error
                                throw new ArgumentOutOfRangeException(nameof(indexToChange4), "Invalid index.");
                            }
                            Console.WriteLine($"Token is now in state: {token.GetState()}");

                            Console.WriteLine($"Lembar Dadu: {dice.ThrowDice()}");

                            Console.WriteLine($"Player Length {this.players.Length}");
                            Console.WriteLine($"Token is now in ID: {(playerNumber, diceResult)}");
                            Console.WriteLine($"Jumlah Pemain: {this.players.Length}");
                           
                            //ludoBoard.DisplayBoard();
                            this.NotChangeTurn();
                            break;

                        case "5":
                            Console.WriteLine("Pergi Dari Memilih");
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a valid option (1-4).");
                            this.NotChangeTurn();
                            break;
                    }

                } while (userInput != "5");
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


        
    }


}

