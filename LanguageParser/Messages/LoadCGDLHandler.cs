using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Messages
{
    public class LoadCGDLHandler : ICommandHandler<LoadCGDL>
    {
        private readonly ITimeProvider timeProvider;
        private readonly Lexer lexer;
        private readonly CGDLParser parser;

        public LoadCGDLHandler(ITimeProvider timeProvider, Lexer lexer, CGDLParser parser)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.lexer = lexer ?? throw new System.ArgumentNullException(nameof(lexer));
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public void Handle(LoadCGDL command, IEventDispatcher eventDispatcher)
        {
            var tokens = lexer.Tokenize(command.CGDL);
            var commands = parser.Parse(tokens);
            if (commands.Any())
            {
                var @event = new CGDLLoaded(timeProvider.Now, command.ProcessId, commands);
                eventDispatcher.Dispatch(@event);
            }
        }
    }
}
