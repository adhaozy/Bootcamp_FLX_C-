using System;
namespace ITD.OOP1.Ludo
{
	// Nice colors of a Ludo game :) 
	public enum GameColor { Gul, Blå, Rød, Grøn };
    public enum GameState { InPlay, Finished };

    public class Game
    {

        private GameState state;
        private int delay = 500; // Output delay

        private int numberOfPlayers;
        private Player[] players;
        private int playerTurn = 1;

        private Dice dice = new Dice();

        // Constructor method of Game class, starts a new game
        public Game()
        {
            SetMessage("Velkommen til Ludo", delay);
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
            Write("Hvor mange spillere?: ", delay);

            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers)){
                    WriteLine();
                    Write("Ugyldig værdi, vælg et tal mellem 2 og 4: ", delay);
                }
            }
            WriteLine("", 1000);
        }

        private void CreatePlayers(){
            SetMessage("Angiv navne");
            this.players = new Player[this.numberOfPlayers];

            for (int i = 0; i < this.numberOfPlayers; i++){
                Write("Hvad hedder spiller #" + (i+1) + ": ", delay);
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
                        tokens[i] = new Token((i+1), GameColor.Grøn);
                        break;
                    case 1:
                        tokens[i] = new Token((i + 1), GameColor.Gul);
                        break;
                    case 2:
                        tokens[i] = new Token((i + 1), GameColor.Blå);
                        break;
                    case 3:
                        tokens[i] = new Token((i + 1), GameColor.Rød);
                        break;
                }
            }
            return tokens;
        }


        private void ShowPlayers(){
            SetMessage("Okay, her er dine spillere:", delay);
            foreach(Player pl in this.players){
                WriteLine(pl.GetDescription(), 1000);
            }
            WriteLine("", 2000);
        }


        private void TakeTurns(){

            while(this.state == GameState.InPlay){
                

                Player myTurn = players[(playerTurn-1)];
                SetMessage(myTurn.GetName + "'s tur", delay);
                WriteLine("Det er " + myTurn.GetDescription() + " tur");
				do
				{
                    Write("Klar til at (K)aste? ", delay);
				}
				while (Console.ReadKey().KeyChar != 'k');
                WriteLine("Du slog: " + dice.ThrowDice().ToString(), delay);
                WriteLine("", delay);
                ShowTurnOptions(myTurn.GetTokens());
                break;
            }

        }

        public void ShowTurnOptions(Token[] tokens)
		{
			int choice = 0;

            WriteLine("Her er dine brikker:");
			foreach (Token tk in tokens)
			{

                Write("Brik #" + tk.GetTokenId() + ": er placeret: " + tk.GetState(), 1000);

                switch(tk.GetState()){
                    case TokenState.Home:
                        if(dice.GetValue() == 6){
                            Write(" <- Kan spilles", delay);
                            choice++;
                        } else {
                            Write(" <- Kan IKKE spilles", delay);
                        }
                        break;
                    case TokenState.InPlay:
                        Write(" <- Kan spilles", delay);
                        choice++;
						break;
                    case TokenState.Safe:
                        Write(" <- Kan spilles", delay);
                        choice++;
						break;
                }
                WriteLine("",  delay);
			}
            WriteLine("", delay);
            WriteLine("Du har "+choice.ToString()+" muligheder i denne tur.", 2000);

            // No options, change turn
            if(choice == 0){
                this.ChangeTurn();
            } else {
                WriteLine("Vælg den #brik du vil spille?");

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

            Write("Skifter spiller om: ", 1000);
			for (int i = 3; i > 0; i--)
			{
                Write(" "+i.ToString()+" ", 1000);
			}

            pause(1000);
            TakeTurns();
	}
    }


}
