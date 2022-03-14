using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleTemplate : ICardTemplate
    {
        private List<ICommand> instantaneous = new List<ICommand>();
        private List<ICommand> permanent = new List<ICommand>();

        public string Template { get; set; }

        public string Name { get; set; }

        public string Illustration { get; set; }

        public string Description { get; set; }

        public IEnumerable<ICommand> Instantaneous => instantaneous;

        public IEnumerable<ICommand> Permanent => permanent;

        public void AddInstantaneous(ICommand command)
        {
            instantaneous.Add(command);
        }

        public void AddPermanent(ICommand command)
        {
            permanent.Add(command);
        }

        public SimpleTemplate(string template, string name, string illustration, string description)
        {
            Template = template;
            Name = name;
            Illustration = illustration;
            Description = description;
        }

    }
}
