using System;
namespace ITD.OOP1.Ludo
{
    public enum TokenState { Home, InPlay, Safe };
    
    public class Token
    {
        private int tokenId;
        private GameColor color;
        private TokenState state;
        internal readonly bool Value;

        // Constructor
        public Token(int id, GameColor clr)
        {
            this.tokenId = id;
            this.color = clr;
            this.state = TokenState.Home;
        }

        public TokenState State
        {
            get { return this.state; }
            set { state = value; }
        } 
        public Token()
        {
            // Default state is Home when a player is created
            this.state = TokenState.Home;
        }
		public int GetTokenId()
		{
            return this.tokenId;
		}

        public GameColor GetColor()
        {
            return this.color;
        }

        // Public method to set the state of the token

        public TokenState GetState()
		{
            return this.state;
		}

        // Method to change the player state
        public void MoveToInPlay()
        {
            // Add conditions if necessary
            
            this.state = TokenState.InPlay;
        }

        // Method to change the player state
        public void MoveToSafe()
        {
            // Add conditions if necessary
            
            this.state = TokenState.Safe;
        }
        // Method to change the TokenStatus from Home to InPlay
        public void ChangeStatusFromHomeToInPlay()
        {
            if (state == TokenState.Home)
            {
                state = TokenState.InPlay;
            }
        }

    }
}
