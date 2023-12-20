namespace LudoLib
{
    // Implement the IPlayer interface in the Player class
    public class Player : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private Team[] tokens;

        private List<Team> _teams;

        public List<Piece> Pieces { get; } = new List<Piece>(); // Initialize the list

        public Player(int id, string name, Team[] tokens)
        {
            Id = id;
            Name = name;
            _teams = new List<Team>();
            this.tokens = tokens;
            this.Color = this.tokens[0].GetColor();
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
        // Add a method to add a team to the player
        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public string GetName
        {
            get
            {
                return Name;
            }
        }

        public GameColor Color
        {
            get;
        }

        public int GetPlayerId()
        {
            return Id;
        }

        public string GetDescription()
        {
            return "#" + this.GetPlayerId() + " " + this.Color + " pemain: " + this.GetName;
        }

        public Team[] GetTokens()
        {
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