using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class ConditionalCommand : ICommand
    {
        public Guid ProcessId => new Guid("C18F0E7B-74AC-446F-873A-5715FF694A3F");

        public Guid Instance { get; private set; }
        public IQuery<bool> Condition { get; set; }
        public ICommand Command { get; set; }
        public IQuery<bool> Query { get; }
        
        private Guid? cardRef;

        [AffectSelf]
        public Guid? SelfRef
        {
            get
            {
                return cardRef;
            }
            set
            {
                cardRef = value;
                if (value.HasValue)
                {
                    Command.SetAffactSelfRef(value.Value);
                }
            }
        }

        [Concept(Description = "Only dispatch the command if the query returns true. Use the If keyword to utilize this.")]
        public ConditionalCommand(IQuery<bool> query, ICommand command)
        {
            Instance = Guid.NewGuid();
            Query = query ?? throw new ArgumentNullException(nameof(query));
            Command = command ?? throw new ArgumentNullException(nameof(command));
        }
    }
}
