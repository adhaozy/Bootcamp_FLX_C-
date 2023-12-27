using System;
using System.Collections.Generic;

namespace LudoLib
{
    /// <summary>
    /// Represents a player in a Ludo game.
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Gets or sets the unique identifier of the player.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        // Store the teams associated with the player
        private List<Team> _teams;

        /// <summary>
        /// Gets the list of pieces owned by the player.
        /// </summary>
        public List<Piece> Pieces { get; } = new List<Piece>();

        /// <summary>
        /// Gets the color associated with the player.
        /// </summary>
        public GameColor Color { get; }

        // Store the tokens (teams) associated with the player
        private Team[] tokens;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of the player.</param>
        /// <param name="name">The name of the player.</param>
        /// <param name="tokens">The teams associated with the player.</param>
        public Player(int id, string name, Team[] tokens)
        {
            Id = id;
            Name = name;
            _teams = new List<Team>();
            this.tokens = tokens;
            this.Color = this.tokens[0].GetColor();
        }

        /// <summary>
        /// Adds a piece to the player's list of pieces.
        /// </summary>
        /// <param name="piece">The piece to be added.</param>
        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }

        /// <summary>
        /// Adds a team to the player's list of teams.
        /// </summary>
        /// <param name="team">The team to be added.</param>
        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        public string GetName
        {
            get { return Name; }
        }

        /// <summary>
        /// Gets the unique identifier of the player.
        /// </summary>
        public int GetPlayerId()
        {
            return Id;
        }

        /// <summary>
        /// Gets a description of the player.
        /// </summary>
        public string GetDescription()
        {
            return "#" + this.GetPlayerId() + " " + this.Color + " player: " + this.GetName;
        }

        /// <summary>
        /// Gets the teams associated with the player.
        /// </summary>
        public Team[] GetTokens()
        {
            return this.tokens;
        }

        /// <summary>
        /// Gets the name of the player.
        /// </summary>
        /// <returns>The name of the player.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        string IPlayer.GetName()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the color of the player.
        /// </summary>
        /// <returns>The color of the player as a GameColor enumeration.</returns>
        /// <exception cref="NotImplementedException">Thrown when the method is not implemented.</exception>
        public GameColor GetColor()
        {
            throw new NotImplementedException();
        }
    }
}
