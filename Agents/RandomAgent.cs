using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using System;
using System.Linq;

namespace Agents
{
    internal class RandomAgent : ICGOLAgent
    {
        private readonly IEventRecorder recorder;
        private readonly IQueryDispatcher dispatcher;

        public RandomAgent(IEventRecorder recorder, IQueryDispatcher dispatcher)
        {
            this.recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public ICommand Choose(IEvent[] state)
        {
            recorder.Replay(state);
            var player = dispatcher.Dispatch(new CurrentPlayer());
            var actions = dispatcher.Dispatch(new GetAvailableActions(player?.Index));
            
            if (actions == null || !actions.Any())
                throw new Exception("No actions available!");

            var action = actions.Random();
            return action.Command;
        }
    }
}
