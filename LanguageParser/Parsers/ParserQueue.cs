using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    internal class ParserQueue : IParserQueue
    {
        private readonly Queue<IToken> tokenStack;
        public IToken LookAhead1 { get; private set; }
        public IToken LookAhead2 { get; private set; }
        public bool HasTokens => tokenStack.Any();

        public ParserQueue(IEnumerable<IToken> tokens)
        {
            tokenStack = new Queue<IToken>();
            foreach (var token in tokens)
            {
                if (token is Comment)
                    continue; // Skip comments

                tokenStack.Enqueue(token);
            }

            LookAhead1 = Pop();
            LookAhead2 = Pop();
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
            return tokenStack.Any() ? tokenStack.Dequeue() : new SequenceTerminator();
        }

        private void Validate<T>(IToken token)
        {
            if (!(token is T))
                throw new GDLParserException($"Expected {typeof(T).Name} but found {LookAhead1}");
        }

        public void ApplyToken<T>(Action<T> callback) where T : IToken
        {
            // We only call the callback action if the types are a match
            if (LookAhead1 is T value)
                callback(value);
        }
    }
}
