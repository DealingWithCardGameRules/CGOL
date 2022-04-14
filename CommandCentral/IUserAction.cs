using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IUserAction
    {
        ICommand Command { get; }
        string Label { get; }
    }
}
