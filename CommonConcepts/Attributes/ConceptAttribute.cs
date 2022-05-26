using System;
using System.Reflection;

namespace dk.itu.game.msc.cgol.CommonConcepts.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConceptAttribute : Attribute
    {
        public string? Description { get; set; }
    }

    public static class ConceptAttributeHelper
    {
        public static string? GetConceptDescription(this ConstructorInfo ctor)
        {
            var concept = ctor.GetCustomAttribute<ConceptAttribute>();
            if (concept != null)
                return concept.Description;
            return null;
        }
    }
}
