using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class CGDLParser : IParser
    {
        private Stack<IToken> tokenStack;

        public CGDLParser(IInterpolator interpolator)
        {

        }

        private void LoadSequenceStack(IEnumerable<IToken> tokens)
        {
            tokenStack = new Stack<IToken>();
            foreach (var token in tokens)
            {
                tokenStack.Push(token);
            }
        }

        private IToken ReadToken(IToken token)
        {
            throw new NotImplementedException();
        }
    }
}
