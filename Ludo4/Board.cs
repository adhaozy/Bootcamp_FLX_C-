namespace LudoLib
{
    public class Board : IBoard
    {
        private int[] _safePositions;

        public Board(int boardSize)
        {
            // Initialize the board and safe positions
            _safePositions = new int[boardSize];
            SetSafeSquares();
        }

        public void SetSafeSquares()
        {
            // Set safe squares on the board
            for (int i = 0; i < _safePositions.Length; i++)
            {
                // Example: Set every 5th position as safe
                if ((i + 1) % 5 == 0)
                {
                    _safePositions[i] = 1; // You can use any value to represent a safe square
                }
                else
                {
                    _safePositions[i] = 0;
                }
            }
        }

        public int[] GetSafeSquares()
        {
            return _safePositions;
        }
    }
}