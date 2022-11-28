using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agents
{
    public class RandomAgent : ICGOLAgent
    {
        private readonly IEventRecorder recorder;
        private readonly IQueryDispatcher dispatcher;

        public RandomAgent(IEventRecorder recorder, IQueryDispatcher dispatcher)
        {
            this.recorder = recorder ?? throw new ArgumentNullException(nameof(recorder));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<ICommand> Choose(IEvent[] state)
        {
            await recorder.Replay(state);
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            var actions = (await dispatcher.Dispatch(new GetAvailableActions(player?.Index)))();
            
            if (actions == null || !await actions.AnyAsync())
                throw new Exception("No actions available!");

            return await Expand(actions.Select(a=>a.Command)).Random();
        }

        public async IAsyncEnumerable<ICommand> Expand(IAsyncEnumerable<ICommand> cmds) 
        {
            await foreach (var cmd in cmds.Select(a => a))
            {
                if (cmd is PlayCard play)
                {
                    await foreach (var choice in play.Card.Choices(dispatcher))
                        yield return new PlayCard(await play.Source.Value(dispatcher), play.Destination, choice);
                }
                else
                {
                    yield return cmd;
                }
            }
        }
    }
}
