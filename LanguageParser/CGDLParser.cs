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
            // [[<template> ]<action>\n]*
            
            while (queue.HasTokens) 
            {
                if (!(queue.LookAhead1 is SequenceTerminator))
                {
                    string? inst = null;
                    string? perm = null;
                    if (queue.LookAhead1 is InstantaneousKeyword)
                    {
                        queue.DiscardToken();
                        inst = queue.ReadToken<StringLiteral>().Value;
                        queue.DiscardToken();
                    }
                    else if (queue.LookAhead1 is PermanentKeyword)
                    {
                        queue.DiscardToken();
                        perm = queue.ReadToken<StringLiteral>().Value;
                        queue.DiscardToken();
                    }

                    var command = ParseAction();
                    if (command != null)
                    {
                        if (inst != null)
                            yield return new AddInstantaniousEffectToCard(inst, command);
                        else if (perm != null)
                            yield return new AddPermanentEffectToCard(perm, command);
                        else
                            yield return command;
                    }
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
            string? playLabel = null;
            if (queue.LookAhead1 is PlayKeyword)
            {
                queue.DiscardToken();
                play = true;

                if (queue.LookAhead1 is StringLiteral)
                {
                    playLabel = queue.ReadToken<StringLiteral>().Value;
                    queue.DiscardToken();
                }
            }

            conceptParser.Parse(queue);
            var output = conceptParser.Result;

            if (play)
                output = new PostponeCommand(output, playLabel);

            if (condition != null)
                output = new ConditionalCommand(condition, output);

            return output;
        }
    }
}
