using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState
{
    internal interface ICommandRepositoryQueries
    {
        Task<Func<IAsyncEnumerable<IUserAction>>> GetCommands(int? playerIndex = null);
    }
}