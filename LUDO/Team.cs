using System;
namespace Iqbal
{
    public enum TokenState { Home, InPlay, Safe };
    
    public class Team
    {
        private int tokenId;
        private GameColor color;
        private TokenState state;
        internal readonly bool Value;

        // Constructor
        public Team(int id, GameColor clr)
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
        public Team()
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

        

    }
}
