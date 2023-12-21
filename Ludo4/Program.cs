using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using Ludo4;
using LudoLib;

class Program
{
        static async Task Main(string[] args)
        {
            
        Game game = new Game();
       
        // ... rest of your code
        }
}

    



class Game
{
    private GameState state;
    private GameController _gameController;
    private int delay = 1000; // Output delay
    private int numberOfPlayers;
    private int playerTurn = 1;
    private Player[] players;

    static int diceMaxValue = 7;
    static int diceMinValue = 1;

    Dice dice = new Dice(diceMinValue,diceMaxValue);
    GameController gameController = new GameController();
    public Game()
    {
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
        WriteLine("", 2000);
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
            WriteLine("Lemparan Dadu:" + dice.ThrowDice().ToString(), delay);
            int diceResult = dice.GetValue();
            WriteLine($"{diceResult}", delay);
            Console.WriteLine(diceResult);

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
        if (diceResult != (diceMaxValue-1))
        {

            // Replace with the actual color you have

            Console.WriteLine(diceResult);
            Console.WriteLine("Choose a color:");
            Console.WriteLine("1. Red");
            Console.WriteLine("2. Blue");
            this.Turn();







        }
        else
        {
            
            int result = gameController.ChangeTurn(playerNumber);
            Console.WriteLine($"Result of ChangeTurn: {result}");

            Console.WriteLine("2. Blue");
            this.Turn();

        }


    }
    private void Turn()
    {
        Player myTurn = players[(playerTurn - 1)];
        

        int playerNumber = myTurn.GetPlayerId();
        Console.WriteLine($"playerNumber: {playerNumber}");
        int result = gameController.ChangeTurn(playerNumber);
        Console.WriteLine($"Result of ChangeTurn: {result}");
        //TakeTurns();

    }

    private void AddTurn()
    {
        Player myTurn = players[(playerTurn - 1)];


        int playerNumber = myTurn.GetPlayerId();
        Console.WriteLine($"playerNumber: {playerNumber}");
        int result = gameController.NotChangeTurn(playerNumber);
        Console.WriteLine($"Result of NotChangeTurn: {result}");
        WriteLine("", 2000);
        //TakeTurns();

    }
}
