using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PlayCollectionAttribute : Attribute
    {
    }

    public static class PlayFromAttributeHelper
    {
        public static IEnumerable<string> GetPlayFroms(this ICommand command)
        {
            return command.
                    GetType().
                    GetProperties().
                    Where(p => p.IsDefined(typeof(PlayCollectionAttribute), false)).
                    Select(p => p.GetValue(command)).
                    Cast<string>();
        }
    }
}