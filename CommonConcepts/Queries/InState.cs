using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class InState : IQuery<bool>
    {
        public string State { get; }

        public InState(string state)
        {
            State = state;
        }
    }
}
