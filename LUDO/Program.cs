using Iqbal;
using System;

namespace ITD.OOP1.Ludo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Start a new Ludo Game 
            // by making an instans of game class
            Game Ludo = new Game();
            Ludo.StartGame();
            // Initialize the array of Token objects



            Token[] tokens = new Token[4];
            // Initialize the array elements (assuming you have a constructor for Token)
            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = new Token();
            }


            
        }
    }
}
