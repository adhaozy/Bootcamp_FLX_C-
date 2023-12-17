using System;

namespace Iqbal
{
    // Define the interface for Player
    public interface IPlayer
    {
        string GetName { get; }
        GameColor Color { get; }
        int GetPlayerId();
        string GetDescription();
        Team[] GetTokens();
    }

    
}
