using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class SimpleBuilder<T>
    {
        private readonly List<object?> arguments = new List<object?>();
        private readonly Type type;

        public IEnumerable<Type> ArgumentTypes => parameters.Select(p => p.ParameterType);
        private IEnumerable<ParameterInfo> parameters;

        public SimpleBuilder(Type type)
        {
            if (type.GetInterface(typeof(T).Name) == null)
                throw new Exception($"The type must inherit from {typeof(T).Name}");

            var ctors = type.GetConstructors();
            if (ctors != null)
            {
                parameters = ctors.Single().GetParameters();
            }
            else
            {
                parameters = new ParameterInfo[0];
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
                var requiredParameters = parameters.Count(p => !p.IsOptional);
                var optionalParameters = ArgumentTypes.Count();
                if (arguments.Count() < requiredParameters)
                {
                    if (requiredParameters == optionalParameters)
                        throw new GDLParserException($"The concept {type.Name} expects {requiredParameters} arguments but found {arguments.Count().Pluralize("arguments")}");
                    else
                        throw new GDLParserException($"The concept {type.Name} expects between {requiredParameters.Pluralize("arguments")} and {optionalParameters.Pluralize("arguments")} but found {arguments.Count().Pluralize("arguments")}");
                }  
                
                for (int i = 0; i < arguments.Count(); i++)
                {
                    if (arguments.ElementAt(i)?.GetType() != ArgumentTypes.ElementAt(i))
                        throw new GDLParserException($"The concept {type.Name} expects the following parameter {"types".Pluralize(optionalParameters)} [{string.Join(",", ArgumentTypes.Select(t => t.Name))}] but found [{string.Join(",", arguments.Select(a => a?.GetType().Name??"<none>"))}] {"arguments".Pluralize(arguments.Count())}");
                }

                return (T)Activator.CreateInstance(type, 
                    BindingFlags.CreateInstance |
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.OptionalParamBinding,
                    null, arguments.ToArray(), CultureInfo.CurrentCulture);
            }

            return (T)Activator.CreateInstance(type);
        }
    }
}
