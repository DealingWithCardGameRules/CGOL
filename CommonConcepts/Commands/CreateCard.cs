using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateCard : ICommand
    {
        public Guid ProcessId => new Guid("DE353A49-5525-4366-9D07-6FBB96F33DFA");

        public string Template { get; }
        public string Name { get; }
        public string Illustration { get; internal set; }
        public string Description { get; internal set; }

        public CreateCard(string template, string? name = null, string? illustration = null, string? description = null)
        {
            Template = template;
            Name = name ?? template;
            Illustration = illustration ?? string.Empty;
            Description = description ?? string.Empty;
        }
    }
}
