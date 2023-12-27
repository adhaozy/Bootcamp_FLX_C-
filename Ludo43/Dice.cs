namespace LudoLib
{
    /// <summary>
    /// Represents a standard six-sided dice used in various board games.
    /// </summary>
    public class Dice
    {
        private int diceValue;
        private Random rnd;

        /// <summary>
        /// Gets the minimum value that can be rolled on the dice.
        /// </summary>
        public int MinDiceValue { get; private set; }

        /// <summary>
        /// Gets the maximum value that can be rolled on the dice.
        /// </summary>
        public int MaxDiceValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class with default minimum and maximum values (1 and 6).
        /// </summary>
        public Dice() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Dice"/> class with specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value that can be rolled on the dice.</param>
        /// <param name="max">The maximum value that can be rolled on the dice.</param>
        /// <exception cref="ArgumentException">Thrown when the minimum value is greater than or equal to the maximum value.</exception>
        public Dice(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value must be less than max value");
            }

            MinDiceValue = min;
            MaxDiceValue = max;
            rnd = new Random();
            diceValue = rnd.Next(MinDiceValue, MaxDiceValue + 1);
        }

        /// <summary>
        /// Rolls the dice and returns the result.
        /// </summary>
        /// <returns>The value rolled on the dice.</returns>
        public int ThrowDice()
        {
            diceValue = rnd.Next(MinDiceValue, MaxDiceValue + 1);
            return diceValue;
        }

        /// <summary>
        /// Gets the current value on the dice.
        /// </summary>
        /// <returns>The current value on the dice.</returns>
        public int GetValue()
        {
            return diceValue;
        }
    }
}
