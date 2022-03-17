using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl
{
    public class CGDLService
    {
        private readonly IDispatcher dispatcher;
        private readonly CardGameDLParser parser;

        public CGDLService(IDispatcher dispatcher, CardGameDLParser parser)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public void Dispatch(ICommand command)
        {
            dispatcher.Dispatch(command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            return dispatcher.Dispatch<T>(query);
        }

        public IEnumerable<ICommand> Parse(string cgdl)
        {
            return parser.Parse(cgdl);
        }
    }
}