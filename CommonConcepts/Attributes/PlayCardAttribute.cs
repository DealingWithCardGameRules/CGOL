using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
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

            if (property != null)
            {
                if (property.PropertyType == typeof(Guid))
                {
                    property.SetValue(command, cardId);
                }
                else if (property.PropertyType == typeof(MaybeChoice<Guid>))
                {
                    ((MaybeChoice<Guid>)property.GetValue(command)).Choose(cardId);
                }
                else if (property.PropertyType == typeof(Maybe<Guid>))
                {
                    property.SetValue(command, new Maybe<Guid>(cardId));
                }
                else if (property.PropertyType == typeof(MaybeQuery<Guid>))
                {
                    property.SetValue(command, new MaybeQuery<Guid>(cardId));
                }
            }
        }
    }
}