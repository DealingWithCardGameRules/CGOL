using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public class ConceptParser : IParser<ICommand?>
    {
        private readonly IInterpolator interpolator;
        private readonly IParser<object> literalParser;

        public ICommand? Result { get; private set; }

        public ConceptParser(IInterpolator interpolator, IParser<object> literalParser)
        {
            this.interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
            this.literalParser = literalParser ?? throw new ArgumentNullException(nameof(literalParser));
        }

        public void Parse(IParserStack stack)
        {
            // {string_value}[ <literal>]*
            var concept = stack.ReadToken<Concept>();
            var type = interpolator.ResolveCommand(concept.Name) ?? throw new GDLParserException($"Unknown concept {concept.Name}. Please make sure all concepts are loaded before you parse again.");
            stack.DiscardToken();

            var builder = new SimpleBuilder<ICommand>(type);
            foreach (var _ in builder.ArgumentTypes)
            {
                literalParser.Parse(stack);
                var literal = literalParser.Result;
                builder.SetNextArgument(literal);
            }
            Result = builder.Build();
        }
    }
}
