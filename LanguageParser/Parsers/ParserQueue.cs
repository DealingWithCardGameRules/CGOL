using dk.itu.game.msc.cgol.Parser.Tokens;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Parser.Parsers
{
    internal class ParserQueue : IParserQueue
    {
        private readonly IEnumerator<Token> tokenEnumerator;
        public Token LookAhead1 { get; private set; }
        public Token LookAhead2 { get; private set; }
        public bool HasTokens => hasNext || !(LookAhead1 is SequenceTerminator);
        private bool hasNext = true;

        public ParserQueue(IEnumerable<Token> tokens)
        {
            tokenEnumerator = tokens.GetEnumerator();
            LookAhead1 = Pop();
            LookAhead2 = Pop();
        }

        public T ReadToken<T>() where T : Token
        {
            Validate<T>(LookAhead1);
            return (T)LookAhead1;
        }

        public void DiscardToken()
        {
            LookAhead1 = LookAhead2;
            LookAhead2 = Pop();
        }

        public void DiscardToken<T>()
        {
            Validate<T>(LookAhead1);
            DiscardToken();
        }

        public void ApplyToken<T>(Action<T> callback) where T : Token
        {
            // We only call the callback action if the types are a match
            if (LookAhead1 is T value)
                callback(value);
        }

        private Token Pop()
        {
            do
            {
                hasNext = tokenEnumerator.MoveNext();
            }
            while (hasNext && tokenEnumerator.Current is Comment);
            return hasNext ? tokenEnumerator.Current : new SequenceTerminator();
        }

        private void Validate<T>(Token token)
        {
            if (!(token is T))
                throw new GDLParserException($"Expected {typeof(T).Name} but found {LookAhead1}");
        }
    }
}
