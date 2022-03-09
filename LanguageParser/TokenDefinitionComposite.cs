using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class TokenDefinitionComposite : ITokenDefinition
    {
        private readonly IEnumerable<ITokenDefinition> definitions;

        public TokenDefinitionComposite(params ITokenDefinition[] definitions)
        {
            this.definitions = definitions;
        }

        public ITokenMatch? Match(string input)
        {
            foreach (var definition in definitions)
            {
                var match = definition.Match(input);
                if (match != null)
                    return match;
            }

            return null;
        }
    }
}