using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    internal class ParserQueue : IParserQueue
    {
        private readonly Queue<Token> tokenStack;
        public Token LookAhead1 { get; private set; }
        public Token LookAhead2 { get; private set; }
        public bool HasTokens => tokenStack.Any() || !(LookAhead1 is SequenceTerminator);

        public ParserQueue(IEnumerable<Token> tokens)
        {
            tokenStack = new Queue<Token>();
            foreach (var token in tokens)
            {
                if (token is Comment)
                    continue; // Skip comments

                tokenStack.Enqueue(token);
            }

            LookAhead1 = Pop();
            LookAhead2 = Pop();
        }

        public Token ReadToken(Type type)
        {
            dynamic token = GetType().GetMethod(nameof(ReadToken)).MakeGenericMethod(type).Invoke(this, new object[0]);
            return token;
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

        private Token Pop()
        {
            return tokenStack.Any() ? tokenStack.Dequeue() : new SequenceTerminator();
        }

        private void Validate<T>(Token token)
        {
            if (!(token is T))
                throw new GDLParserException($"Expected {typeof(T).Name} but found {LookAhead1}");
        }

        public void ApplyToken<T>(Action<T> callback) where T : Token
        {
            // We only call the callback action if the types are a match
            if (LookAhead1 is T value)
                callback(value);
        }
    }
}
