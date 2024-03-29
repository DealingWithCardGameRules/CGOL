﻿using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AffectSelfAttribute : Attribute
    {
    }

    public static class AffectSelfAttributeHelper
    {
        public static void SetAffactSelfRef(this ICommand command, Guid cardId)
        {
            var properties = command.GetType().GetProperties().
                Where(p => p.IsDefined(typeof(AffectSelfAttribute), false));
            foreach (var property in properties)
                property.SetValue(command, cardId);
        }
    }
}