using Iqbal;
using System;

namespace ITD.OOP1.Ludo
{
    class Program
    {
        static int delay = 500; // Output delay
        static int numberOfPlayers;
        static Player[] players;

        static void Main(string[] args)
        {
            // Set the desired min and max values
            //int minDiceValue = 1;
            //int maxDiceValue = 6;

            // Create an instance of GameController with custom min and max values
            //GameController gameController = new GameController(minDiceValue, maxDiceValue);

            // Access the Dice instance through the property
            //Dice dice = gameController.Dice;

            // Use the dice in the GameController or any other part of your program
            //int thrownValue = dice.ThrowDice(); // Assuming ThrowDice is asynchronous
            //Console.WriteLine($"Dice value: {thrownValue}");

            SetMessage("Selamat datang di Ludo", delay);
            SetNumberOfPlayers();
            CreatePlayers();
            ShowPlayers();
            // ... rest of your code
        }

        private static void WriteLine(string txt = "", int dl = 0)
        {
            Thread.Sleep(dl);
            Console.WriteLine(txt);
        }

        private static void WriteCenterLine(string txt = "", int dl = 0)
        {
            string textToEnter = txt;
            Thread.Sleep(dl);
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }

        private static void Write(string txt, int dl = 0)
        {
            Thread.Sleep(dl);
            Console.Write(txt);
        }

        private static void Clear()
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------");
            Console.WriteLine();
        }

        // Make MainMenu
        private static void SetMessage(string message, int dl = 0)
        {
            Console.Clear();
            WriteCenterLine("---------- Ludo ----------", 0);
            WriteCenterLine(message, dl);
            Console.WriteLine();
        }

        private static void pause(int dl)
        {
            Thread.Sleep(dl);
        }

        private static void SetNumberOfPlayers()
        {
            Write("Berapa banyak pemain?: ", delay);

            while (numberOfPlayers < 2 || numberOfPlayers > 4)
            {
                if (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out numberOfPlayers))
                {
                    WriteLine();
                    Write("Nilai tidak valid, pilih angka antara 2 dan 4: ", delay);
                }
            }
            WriteLine("", 1000);
        }

        private static void CreatePlayers()
        {
            SetMessage("Masukkan nama");
            players = new Player[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Write("Siapa nama pemainnya #" + (i + 1) + ": ", delay);
                string name = Console.ReadLine();

                Team[] tkns = AssingTokens(i);

                players[i] = new Player((i + 1), name, tkns);
            }
        }

        private static Team[] AssingTokens(int colorIndex)
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

        private static void ShowPlayers()
        {
            SetMessage("Oke, inilah pemain Anda:", delay);
            foreach (Player pl in players)
            {
                WriteLine(pl.GetDescription(), 1000);
            }
            WriteLine("", 2000);
        }
    }
}
