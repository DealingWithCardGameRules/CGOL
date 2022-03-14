using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICardTemplate
    {
        string Template { get; }
        string Name { get; }
        string Illustration { get; }
        string Description { get; }
        IEnumerable<ICommand> Instantaneous { get; }
        IEnumerable<ICommand> Permanent { get; }
        void AddInstantaneous(ICommand command);
        void AddPermanent(ICommand command);
    }
}
