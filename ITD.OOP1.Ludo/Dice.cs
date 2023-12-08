using System;
namespace ITD.OOP1.Ludo
{
    public class Dice
    {
        // Field dice value
        private int diceValue;
        private Random rnd = new Random();

        // Constructor, throw dice
        public Dice()
        {
            this.diceValue = this.rnd.Next(1, 7);
        }

        // method throw dice
        public int ThrowDice(){

            this.diceValue = this.rnd.Next(1,7);

			for (int i = 3; i > 0; i--)
			{
				Console.Write(" . ");
				System.Threading.Thread.Sleep(500);

			}

            return this.diceValue;
        }

        // Look at dice and read its value
        public int GetValue(){
            return this.diceValue;
        }
    }
}
