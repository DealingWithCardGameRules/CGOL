using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    internal class ParserStack : IParserStack
    {
        private readonly Stack<IToken> tokenStack;
        public IToken LookAhead1 { get; private set; }
        public IToken LookAhead2 { get; private set; }
        public bool HasTokens => tokenStack.Any();

        public ParserStack(IEnumerable<IToken> tokens)
        {
            tokenStack = new Stack<IToken>();
            foreach (var token in tokens)
                tokenStack.Push(token);

            LookAhead1 = Pop();
            LookAhead2 = Pop();
        }

        public ParserStack()
        {
        }

        public IToken ReadToken(Type type)
        {
            dynamic token = GetType().GetMethod(nameof(ReadToken)).MakeGenericMethod(type).Invoke(this, new object[0]);
            return token;
        }

        public T ReadToken<T>() where T : IToken
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

        private IToken Pop()
        {
            return tokenStack.Any() ? tokenStack.Pop() : new SequenceTerminator();
        }

        private void Validate<T>(IToken token)
        {
            if (!(token is T))
                throw new GDLParserException($"Expected {typeof(T)} but found {LookAhead1.GetType()}");
        }

        public void ApplyToken<T>(Action<T> callback) where T : IToken
        {
            // We only call the callback action if the types are a match
            if (LookAhead1 is T value)
                callback(value);
        }
    }
}
