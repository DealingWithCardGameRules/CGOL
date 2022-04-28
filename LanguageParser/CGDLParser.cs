using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    string? when = null;
                    SupportedEvent? whenEvent = null;

                    if (queue.LookAhead1 is WhenKeyword)
                    {
                        queue.DiscardToken();
                        when = queue.ReadToken<StringLiteral>().Value;
                        queue.DiscardToken();
                        whenEvent = queue.ReadToken<EventType>().Value;
                        queue.DiscardToken();
                    }
                    // Obsolete
                    else if (queue.LookAhead1 is InstantaneousKeyword)
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
                        if (when != null && whenEvent != null)
                        {
                            switch(whenEvent.Value)
                            {
                                case SupportedEvent.Played:
                                    yield return new AddInstantaniousEffectToCard(when, command);
                                    break;
                                case SupportedEvent.Active:
                                    yield return new AddPermanentEffectToCard(when, command);
                                    break;
                                case SupportedEvent.Drawn:
                                    yield return new AddAcquisitionEffectToCard(when, command);
                                    break;
                            }
                        }
                        // Obsolete
                        else if (inst != null)
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

            ICommand? output;
            if (queue.LookAhead1 is Colon)
            {
                queue.DiscardToken();
                output = new CommandBundle(ParseCommandBundle().ToArray());
            }
            else
            {
                conceptParser.Parse(queue);
                output = conceptParser.Result;
            }

            if (play)
                output = new PostponeCommand(output, playLabel);

            if (condition != null)
                output = new ConditionalCommand(condition, output);

            return output;
        }

        private IEnumerable<ICommand> ParseCommandBundle()
        {
            while (queue.LookAhead1 is SequenceTerminator && queue.LookAhead2 is Tabulator)
            {
                queue.DiscardToken<SequenceTerminator>();
                queue.DiscardToken<Tabulator>();

                conceptParser.Parse(queue);
                if (conceptParser.Result != null)
                    yield return conceptParser.Result;
            }
        }
    }
}
