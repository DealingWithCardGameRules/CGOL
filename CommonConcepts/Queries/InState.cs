using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
