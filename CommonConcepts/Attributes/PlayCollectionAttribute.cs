﻿using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PlayCollectionAttribute : Attribute
    {
    }

    public static class PlayFromAttributeHelper
    {
        public static IEnumerable<string> GetPlayFroms(this ICommand command)
        {
            var values = command.
                            GetType().
                            GetProperties().
                            Where(p => p.IsDefined(typeof(PlayCollectionAttribute), false)).
                            Select(p => p.GetValue(command));
            
            foreach (var value in values)
            {
                if (value is string strValue)
                {
                    if (strValue != null)
                        yield return strValue;
                }
                else if (value is IEnumerable<string> arrayValue)
                {
                    foreach (var val in arrayValue)
                    {
                        if (val != null)
                            yield return val;
                    }
                }
            }
        }

        public static IEnumerable<MaybeQuery<string>> GetPlayFromMaybeQueries(this ICommand command)
        {
            var values = command.
                            GetType().
                            GetProperties().
                            Where(p => p.IsDefined(typeof(PlayCollectionAttribute), false)).
                            Select(p => p.GetValue(command));

            foreach (var value in values)
            {
                if (value is MaybeQuery<string> MQValue)
                {
                    if (MQValue != null)
                        yield return MQValue;
                }
                else if (value is IEnumerable<MaybeQuery<string>> MQArrayValue)
                {
                    foreach (var val in MQArrayValue)
                    {
                        if (val != null)
                            yield return val;
                    }
                }
                else if (value is string strValue)
                {
                    if (strValue != null)
                        yield return new MaybeQuery<string>(strValue);
                }
                else if (value is IEnumerable<string> arrayValue)
                {
                    foreach (var val in arrayValue)
                    {
                        if (val != null)
                            yield return new MaybeQuery<string>(val);
                    }
                }
            }
        }
    }
}