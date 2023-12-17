using System;
namespace Iqbal
{
    public class Player
    {
        private readonly int playerId;
        private readonly string name;
        private Team[] tokens;

        // Constructor new player
        public Player(int id, string playerName, Team[] tokens)
        {
            this.playerId = id;
            this.name = playerName;
            this.tokens = tokens;
            this.Color = this.tokens[0].GetColor();
        }
        public Player()
        {

        }
        // returns name
        // 'tell me your name?'
        public string GetName
        {
            get{
                return this.name;
            }
        }

        public GameColor Color
        {
            get;
        }

        public int GetPlayerId(){
            return this.playerId;
        }

        public string GetDescription(){
            return "#" + this.GetPlayerId() + " " + this.Color + " pemain: " + this.GetName;
        }

        public Team[] GetTokens(){
            return this.tokens;
        }

        public Player(int numberOfTokens)
        {
            tokens = new Team[numberOfTokens];

            // Initialize tokens for the player
            for (int i = 0; i < numberOfTokens; i++)
            {
                tokens[i] = new Team();
            }
        }

        
    }
}
