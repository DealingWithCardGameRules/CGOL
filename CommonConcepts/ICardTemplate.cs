using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICardTemplate
    {
        string Template { get; }
        IEnumerable<ICommand> Instantaneous { get; }
        IEnumerable<ICommand> Permanent { get; }
        void AddInstantaneous(ICommand command);
        void AddPermanent(ICommand command);
    }
}
