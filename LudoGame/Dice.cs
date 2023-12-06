namespace GameControllerLib 

public class Dice
{
    private Random randomDice;

    public Dice() => randomDice = new Random();

    private int GetRandomNumber()
    {
        // Generate a random integer
        return randomDice.Next();
    }

    // Public method to expose the random integer to the outside world
    public int GetRandomNumberPublic()
    {
        // Call the private method to get a random integer
        return GetRandomNumber();
    }
}