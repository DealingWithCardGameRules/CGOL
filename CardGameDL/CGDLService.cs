using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl
{
    public class CGDLService
    {
        private readonly IDispatcher dispatcher;
        private readonly CardGameDLParser parser;
        private readonly Dictionary<string, ICommand[]> library;

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

        public void Parse(string cgdl)
        {
            foreach (var command in parser.Parse(cgdl))
            {
                dispatcher.Dispatch(command);
            }
        }

        public void Parse(string cgdl, string template)
        {
            library.Add(template, parser.Parse(cgdl).ToArray());
        }

        public void Process(string template)
        {
            if (library.ContainsKey(template))
            {
                foreach (var command in library[template])
                {
                    dispatcher.Dispatch(command);
                }
            }
        }
    }
}