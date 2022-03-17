using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public interface ITokenFactory
    {
        IToken Create(string input);
    }

    public class TokenFactory : ITokenFactory
    {
        private readonly Func<IToken> create;

        public TokenFactory(Func<IToken> create)
        {
            this.create = create;
        }

        public IToken Create(string input)
        {
            var result = create();
            result.Parse(input);
            return result;
        }
    }
}
