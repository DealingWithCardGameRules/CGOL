﻿using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class TokenMatch : ITokenMatch
    {
        public IToken Token { get; set; }
        public string Value { get; set; } = string.Empty;
        public string RemainingText { get; set; } = string.Empty;

        public TokenMatch(IToken token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
