﻿using dk.itu.game.msc.cgol.Parser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Parser.Lexers
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