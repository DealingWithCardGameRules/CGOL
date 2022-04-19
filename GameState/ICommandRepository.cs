using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public interface ICommandRepositoryQueries
    {
        IEnumerable<IUserAction> GetCommands(int? playerIndex = null);
    }
}