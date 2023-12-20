using System;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
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
    private GameController _gameController;
    private int delay = 500; // Output delay
    private int numberOfPlayers;
    private int playerTurn = 1;
    private Player[] players;
    public Game()
    {
        SetMessageAsync("Selamat datang di Ludo", delay);
        SetNumberOfPlayers();
        CreatePlayers();
        ShowPlayers();

        //this.state = GameState.InPlay;
        //TakeTurns();

    }

    public async Task StarGame()
    {

        
    }

    private async Task WriteLineAsync(string txt = "", int dl = 0)
    {
        await Task.Delay(dl);
        Console.WriteLine(txt);
    }

    private async Task WriteCenterLineAsync(string txt = "", int dl = 0)
    {
        string textToEnter = txt;
        await Task.Delay(dl);
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
    }

    private async Task WriteAsync(string txt, int dl = 0)
    {
        await Task.Delay(dl);
        Console.Write(txt);
    }

    private async Task SetMessageAsync(string message, int dl = 0)
    {
        Console.Clear();
        await WriteCenterLineAsync("---------- Ludo ----------", 0);
        await WriteCenterLineAsync(message, dl);
        Console.WriteLine();
    }
    private async Task PauseAsync(int dl)
    {
        await Task.Delay(dl);
    }

    private void SetNumberOfPlayers()
    {
        WriteAsync("Berapa banyak pemain?: ", delay);

        while (numberOfPlayers < 2 || numberOfPlayers > 4)
        {
            if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out this.numberOfPlayers))
            {
                WriteLineAsync();
                WriteAsync("Nilai tidak valid, pilih angka antara 2 dan 4: ", delay);
            }
        }
        WriteLineAsync("", 1000);
    }

    private void CreatePlayers()
    {
        SetMessageAsync("Masukkan nama");
        this.players = new Player[this.numberOfPlayers];

        for (int i = 0; i < this.numberOfPlayers; i++)
        {
            WriteAsync("Siapa nama pemainnya #" + (i + 1) + ": ", delay);
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
        SetMessageAsync("Oke, inilah pemain Anda:", delay);
        foreach (Player pl in this.players)
        {
            WriteLineAsync(pl.GetDescription(), 1000);
        }
        WriteLineAsync("", 2000);
    }

    

}
