using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Messages;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl
{
    public class CGDLService
    {
        private readonly IDispatcher dispatcher;
        private readonly CardGameDLParser parser;

        public CGDLService(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Dispatch(ICommand command)
        {
            dispatcher.Dispatch(command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            return dispatcher.Dispatch<T>(query);
        }

        public void Parse(string cgdl)
        {
            dispatcher.Dispatch(new LoadCGDL(cgdl));
        }
    }
}