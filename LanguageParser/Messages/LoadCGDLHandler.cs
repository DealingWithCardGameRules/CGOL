using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser;
using dk.itu.game.msc.cgol.Parser.Lexers;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Parser.Messages
{
    public class LoadCGOLHandler : ICommandHandler<LoadCGOL>
    {
        private readonly ITimeProvider timeProvider;
        private readonly Lexer lexer;
        private readonly CGOLParser parser;

        public LoadCGOLHandler(ITimeProvider timeProvider, Lexer lexer, CGOLParser parser)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.lexer = lexer ?? throw new System.ArgumentNullException(nameof(lexer));
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public async Task Handle(LoadCGOL command, IEventDispatcher eventDispatcher)
        {
            var tokens = lexer.Tokenize(command.CGOL);
            var commands = parser.Parse(tokens);
            if (commands.Any())
            {
                var @event = new CGOLLoaded(timeProvider.Now, command.ProcessId, commands);
                await eventDispatcher.Dispatch(@event);
            }
        }
    }
}
