using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.Parser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.Parser.Parsers
{
    public class ConceptParser<T> : IParser<T>
    {
        private readonly IInterpreter interpolator;
        private readonly IParser<object?> literalParser;

        public T Result { get; private set; }

        public ConceptParser(IInterpreter interpolator, IParser<object?> literalParser)
        {
            this.interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
            this.literalParser = literalParser ?? throw new ArgumentNullException(nameof(literalParser));
        }

        public void Parse(IParserQueue queue)
        {
            // {string_value}[ <literal>]*
            var concept = queue.ReadToken<Concept>();
            var type = interpolator.Resolve<T>(concept.Name) ?? throw new GDLParserException($"Unknown concept {concept.Name}. Please make sure all concepts are loaded before you parse again.");
            queue.DiscardToken();

            var builder = new SimpleBuilder<T>(type);
            foreach (var _ in builder.ArgumentTypes)
            {
                if (queue.LookAhead1 is SequenceTerminator || queue.LookAhead1 is ParenthesesEnd)
                    break;

                literalParser.Parse(queue);
                var literal = literalParser.Result;
                builder.SetNextArgument(literal);
            }

            Result = builder.Build();
        }
    }
}
