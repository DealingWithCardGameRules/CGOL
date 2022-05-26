using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser.Parsers;
using dk.itu.game.msc.cgol.Parser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.Parser
{
    public class CGOLParser
    {
        private readonly IParserQueueFactory factory;
        private readonly IParser<ICommand?> conceptParser;
        private readonly IParser<IQuery<bool>?> queryParser;
        private IParserQueue queue;

        public CGOLParser(IParserQueueFactory factory, IParser<ICommand?> commandParser, IParser<IQuery<bool>?> queryParser)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            conceptParser = commandParser ?? throw new ArgumentNullException(nameof(commandParser));
            this.queryParser = queryParser ?? throw new ArgumentNullException(nameof(queryParser));
        }

        public IEnumerable<ICommand> Parse(IEnumerable<Token> tokens)
        {
            queue = factory.Create(tokens);
            // [[<template> ]<action>\n]*

            while (queue.HasTokens)
            {
                if (!(queue.LookAhead1 is SequenceTerminator))
                {
                    var wrapper = ParseTemplate();
                    var command = ParseAction();

                    if (command != null)
                        yield return wrapper?.Invoke(command) ?? command;
                }

                queue.DiscardToken<SequenceTerminator>();
            }
        }

        private Func<ICommand, ICommand>? ParseTemplate()
        {
            Func<ICommand, ICommand>? wrapper = null;
            queue.ApplyToken<WhenKeyword>(_ =>
            {
                queue.DiscardToken();
                var card = queue.ReadToken<StringLiteral>().Value;
                queue.DiscardToken();
                var whenEvent = queue.ReadToken<EventType>().Value;
                queue.DiscardToken();

                if (card != null)
                {
                    wrapper = cmd => whenEvent switch
                    {
                        SupportedEvent.Played => new AddInstantaniousEffectToCard(card, cmd),
                        SupportedEvent.Active => new AddPermanentEffectToCard(card, cmd),
                        SupportedEvent.Drawn => new AddAcquisitionEffectToCard(card, cmd),
                    };
                }
            });
            if (wrapper != null)
                return wrapper;

            // Obsolete
            queue.ApplyToken<InstantaneousKeyword>(_ =>
            {
                queue.DiscardToken();
                var inst = queue.ReadToken<StringLiteral>().Value;
                queue.DiscardToken();
                if (inst != null)
                    wrapper = cmd => new AddInstantaniousEffectToCard(inst, cmd);
            });
            if (wrapper != null)
                return wrapper;

            // Obsolete
            queue.ApplyToken<PermanentKeyword>(_ =>
            {
                queue.DiscardToken();
                var perm = queue.ReadToken<StringLiteral>().Value;
                queue.DiscardToken();
                if (perm != null)
                    wrapper = cmd => new AddPermanentEffectToCard(perm, cmd);
            });
            return wrapper;
        }

        private ICommand? ParseAction()
        {
            // [If (<query>) ][Play ]<concept>

            var condition = ParseCondition();
            var play = ParsePlay();

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

            if (output == null)
                return null;

            if (play != null)
                output = play.Invoke(output);

            if (condition != null)
                output = condition.Invoke(output);

            return output;
        }

        private Func<ICommand, ICommand>? ParseCondition()
        {
            Func<ICommand, ICommand>? wrapper = null;
            queue.ApplyToken<IfKeyword>(_ =>
            {
                queue.DiscardToken();
                queue.DiscardToken<ParenthesesStart>();
                queryParser.Parse(queue);
                queue.DiscardToken<ParenthesesEnd>();
                var condition = queryParser.Result;

                if (condition != null)
                    wrapper = cmd => new ConditionalCommand(condition, cmd);
            });
            return wrapper;
        }
        private Func<ICommand, ICommand>? ParsePlay()
        {
            Func<ICommand, ICommand>? wrapper = null;
            queue.ApplyToken<PlayKeyword>(_ =>
            {
                queue.DiscardToken();
                string? label = null;
                queue.ApplyToken<StringLiteral>(value =>
                {
                    label = value.Value;
                    queue.DiscardToken();
                });
                wrapper = cmd => new PostponeCommand(cmd, label);
            });
            return wrapper;
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
