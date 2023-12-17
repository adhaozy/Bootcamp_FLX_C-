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
            GameController Ludo = new GameController();
           
            // Initialize the array of Token objects



            Team[] tokens = new Team[4];
            // Initialize the array elements (assuming you have a constructor for Token)
            for (int i = 0; i < tokens.Length; i++)
            {
                tokens[i] = new Team();
            }


            
        }
    }
}
