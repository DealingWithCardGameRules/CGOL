﻿using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetAvailableAction : IQuery<ICommand?>
    {
        public Guid Instance { get; set; }

        public GetAvailableAction(Guid instance)
        {
            Instance = instance;
        }
    }
}