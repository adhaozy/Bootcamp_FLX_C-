using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo4
{
    /// <summary>
    /// Represents the possible states of a Ludo game.
    /// </summary>
    public enum GameState
    {
        /// <summary>
        /// The game is currently in progress.
        /// </summary>
        InPlay,

        /// <summary>
        /// The game has finished, and the winner has been determined.
        /// </summary>
        Finished
    }
}
