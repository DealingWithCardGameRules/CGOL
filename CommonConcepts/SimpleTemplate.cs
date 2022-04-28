using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleTemplate : TagHandler, ICardTemplate
    {
        private List<ICommand> instantaneous = new List<ICommand>();
        private List<ICommand> permanent = new List<ICommand>();
        private List<ICommand> acquisition = new List<ICommand>();

        public string Template { get; set; }

        public IEnumerable<ICommand> Instantaneous => instantaneous;

        public IEnumerable<ICommand> Permanent => permanent;

        public IEnumerable<ICommand> Acquisition => acquisition;

        public void AddInstantaneous(ICommand command)
        {
            instantaneous.Add(command);
        }

        public void AddPermanent(ICommand command)
        {
            permanent.Add(command);
        }

        public void AddAcquisition(ICommand command)
        {
            acquisition.Add(command);
        }

        public SimpleTemplate(string template)
        {
            Template = template;
        }

    }
}
