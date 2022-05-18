using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal interface ICommandRepositoryQueries
    {
        IEnumerable<IUserAction> GetCommands(int? playerIndex = null);
    }
}