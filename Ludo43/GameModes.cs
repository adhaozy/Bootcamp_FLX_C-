using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo4
{
    /// <summary>
    /// Represents the available game modes for Ludo.
    /// </summary>
    public enum GameModes
    {
        /// <summary>
        /// The computer mode where players compete against computer opponents.
        /// </summary>
        COMPUTER,

        /// <summary>
        /// The local mode where players play against each other on the same device.
        /// </summary>
        LOCAL,

        /// <summary>
        /// The online mode where players can connect and play against each other over the internet.
        /// </summary>
        ONLINE
    }
}
