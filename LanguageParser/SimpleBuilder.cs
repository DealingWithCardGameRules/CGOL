using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class SimpleBuilder<T>
    {
        private readonly List<object?> arguments = new List<object?>();
        private readonly Type type;

        public IEnumerable<Type> ArgumentTypes { get; }

        public SimpleBuilder(Type type)
        {
            if (type.GetInterface(typeof(T).Name) == null)
                throw new Exception($"The type must inherit from {typeof(T).Name}");

            var ctors = type.GetConstructors();
            if (ctors != null)
            {
                ArgumentTypes = ctors.Single().GetParameters().Select(p => p.ParameterType);
            }
            else
            {
                ArgumentTypes = new Type[0];
            }

            this.type = type;
        }

        public void SetNextArgument(object value)
        {
            if (!ArgumentTypes.Any())
                throw new GDLParserException($"The concept {type.Name} does not expect any arguments. Please create a constructur with parameters for the concept or remove the arguments.");

            arguments.Add(value);
        }

        internal T Build()
        {
            if (ArgumentTypes.Any())
            {
                if (arguments.Count() != ArgumentTypes.Count())
                    throw new GDLParserException($"The concept {type.Name} expects {ArgumentTypes.Count()} arguments but found {arguments.Count()} arguments");
                
                for (int i = 0; i < arguments.Count(); i++)
                {
                    if (arguments.ElementAt(i)?.GetType() != ArgumentTypes.ElementAt(i))
                        throw new GDLParserException($"The concept {type.Name} expects the following parameter types [{string.Join(",", ArgumentTypes.Select(t => t.Name))}] arguments but found [{string.Join(",", arguments.Select(a => a?.GetType().Name??"<none>"))}] arguments");
                }

                return (T)Activator.CreateInstance(type, arguments.ToArray());
            }

            return (T)Activator.CreateInstance(type);
        }
    }
}
