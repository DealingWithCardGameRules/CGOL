using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class AddCard : ICommand
    {
        public Guid ProcessId => new Guid("C41ED5BD-D463-4B29-BD77-BCAB6FCF1853");
        public string Destination { get; }
        public string Template { get; }

        public AddCard(string template, string deck)
        {
            Template = template;
            Destination = deck;
        }
    }
}
