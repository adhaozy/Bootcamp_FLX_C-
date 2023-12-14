using ITD.OOP1.Ludo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iqbal
{
    public class LudoGame : IPlay
    {
        private readonly IGame gameController;
        private Dice dice = new Dice();
       

        public LudoGame(IGame controller)
        {
            gameController = controller ?? throw new ArgumentNullException(nameof(controller));
        }

        

        public void Play()
        {
            gameController.StartGame();

            for (int i = 0; i < 10; i++) // Play 10 rounds for this example
            {
                Console.WriteLine($"Round {i + 1}");
                dice.ThrowDice().ToString();
                Console.WriteLine();
            }
        }
    }
}
