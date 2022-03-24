using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class CGDLParser
    {
        private readonly IParserQueueFactory factory;
        private readonly IParser<ICommand?> conceptParser;
        private readonly IParser<IQuery<bool>?> queryParser;
        private IParserQueue queue;

        public CGDLParser(IParserQueueFactory factory, IParser<ICommand?> commandParser, IParser<IQuery<bool>?> queryParser)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.conceptParser = commandParser ?? throw new ArgumentNullException(nameof(commandParser));
            this.queryParser = queryParser ?? throw new ArgumentNullException(nameof(queryParser));
        }

        public IEnumerable<ICommand> Parse(IEnumerable<IToken> tokens)
        {
            queue = factory.Create(tokens);
            // [<action>\n]*
            
            while (queue.HasTokens) {
                if (!(queue.LookAhead1 is SequenceTerminator))
                {
                    var command = ParseAction();
                    if (command != null)
                        yield return command;
                }

                queue.DiscardToken<SequenceTerminator>();
            }
        }

        private ICommand? ParseAction()
        {
            // [If (<query>) ][Play ]<concept>

            IQuery<bool>? condition = null;
            if (queue.LookAhead1 is IfKeyword)
            {
                queue.DiscardToken();
                queue.DiscardToken<ParenthesesStart>();
                queryParser.Parse(queue);
                queue.DiscardToken<ParenthesesEnd>();
                condition = queryParser.Result;
            }

            bool play = false;
            if (queue.LookAhead1 is PlayKeyword)
            {
                queue.DiscardToken();
                play = true;
            }

            conceptParser.Parse(queue);
            var output = conceptParser.Result;

            if (play)
                output = new PostponedCommand(output);

            if (condition != null)
                output = new ConditionalCommand(condition, output);

            return output;
        }
    }
}
