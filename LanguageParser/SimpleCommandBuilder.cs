using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class SimpleCommandBuilder
    {
        private List<object> arguments;
        private MethodAttributes methodAttributes;

        public SimpleCommandBuilder(Type type)
        {
            if (type.GetInterface("ICommand") == null)
                throw new Exception("The type must inherit from ICommand");

            var ctors = type.GetConstructors();
            if (ctors != null)
            {
                arguments = new List<object>();
                methodAttributes = ctors.Single().Attributes;
            }
        }

        public void SetNextArgument<T>(T value)
        {

        }
    }
}
