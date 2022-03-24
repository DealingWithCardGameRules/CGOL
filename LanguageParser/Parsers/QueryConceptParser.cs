using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public class QueryConceptParser : IParser<IQuery<bool>?>
    {
        private readonly IInterpolator interpolator;
        private readonly IParser<object?> literalParser;

        public IQuery<bool>? Result { get; private set; }

        public QueryConceptParser(IInterpolator interpolator, IParser<object?> literalParser)
        {
            this.interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
            this.literalParser = literalParser ?? throw new ArgumentNullException(nameof(literalParser));
        }

        public void Parse(IParserQueue queue)
        {
            // {string_value}[ <literal>]*
            var concept = queue.ReadToken<Concept>();
            var type = interpolator.ResolveQuery<bool>(concept.Name) ?? throw new GDLParserException($"Unknown concept {concept.Name}. Please make sure all concepts are loaded before you parse again.");
            queue.DiscardToken();

            var builder = new SimpleBuilder<IQuery<bool>>(type);
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
