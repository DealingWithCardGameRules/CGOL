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
        private readonly IParser<ICommand> conceptParser;
        private IParserQueue queue;

        public CGDLParser(IParserQueueFactory factory, IParser<ICommand> conceptParser)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.conceptParser = conceptParser ?? throw new ArgumentNullException(nameof(conceptParser));
        }

        public IEnumerable<ICommand> Parse(IEnumerable<IToken> tokens)
        {
            queue = factory.Create(tokens);
            // [<action>\n]*
            
            while (queue.HasTokens) {
                yield return ParseAction();
                queue.DiscardToken<SequenceTerminator>();
            }
        }

        private ICommand ParseAction()
        {
            // [Play ]<concept>
            bool play = false;
            if (queue.LookAhead1 is PlayKeyword)
            {
                queue.DiscardToken();
                play = true;
            }

            conceptParser.Parse(queue);
            var output = conceptParser.Result;

            if (play)
                output = new PostPonedCommand(output);

            return output;
        }
    }
}
