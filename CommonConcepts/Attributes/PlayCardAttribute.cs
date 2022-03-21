using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Attributes
{
    public class PlayCardAttribute : Attribute
    {
    }

    public static class PlayCardAttributeHelper
    {
        public static string? GetPlayCard(this ICommand command)
        {
            return command.
                    GetType().
                    GetProperties().
                    Where(p => p.IsDefined(typeof(PlayCardAttribute), false)).
                    Select(p => p.Name).
                    FirstOrDefault();
        }

        public static void SetPlayCard(this ICommand command, Guid cardId)
        {
            var property = command.GetType().GetProperties().
                Where(p => p.IsDefined(typeof(PlayCardAttribute), false)).FirstOrDefault();

            property.SetValue(command, cardId);
        }
    }
}