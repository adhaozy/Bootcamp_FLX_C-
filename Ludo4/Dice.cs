namespace LudoLib
{
    public class Dice
    {
        private int diceValue;
        private Random rnd;
        private int minDiceValue;
        private int maxDiceValue;

        public Dice(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value must be less than max value");
            }

            this.minDiceValue = min;
            this.maxDiceValue = max;
            this.rnd = new Random();
            this.diceValue = this.rnd.Next(this.minDiceValue, this.maxDiceValue + 1);
        }

        public async Task<int> ThrowDice()
        {
            this.diceValue = this.rnd.Next(this.minDiceValue, this.maxDiceValue + 1);
            return this.diceValue;
        }

        public int GetValue()
        {
            return this.diceValue;
        }
    }
}