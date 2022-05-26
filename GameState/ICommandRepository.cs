using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState
{
    internal interface ICommandRepositoryQueries
    {
        IEnumerable<IUserAction> GetCommands(int? playerIndex = null);
    }
}