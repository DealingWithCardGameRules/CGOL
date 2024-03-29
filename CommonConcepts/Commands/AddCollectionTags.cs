﻿using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class AddCollectionTags : ICommand
    {
        public Guid ProcessId => new Guid("20BB8222-EA7B-4840-8394-1B79E56738CC");

        public Guid Instance { get; }
        public string Collection { get; }
        public IEnumerable<string> Tags { get; }

        [Concept(Description = "Add tags to a given collection. Tags are comma separated.")]
        public AddCollectionTags(string collection, string tags)
        {
            Collection = collection;
            Tags = tags.CommaSeperateTrimmed();
        }
    }
}
