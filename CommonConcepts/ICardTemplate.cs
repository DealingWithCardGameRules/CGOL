﻿using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts
{
    public interface ICardTemplate : ITagable
    {
        string Template { get; }
        IEnumerable<ICommand> Instantaneous { get; }
        IEnumerable<ICommand> Permanent { get; }
        IEnumerable<ICommand> Acquisition { get; }
        void AddInstantaneous(ICommand command);
        void AddPermanent(ICommand command);
        void AddAcquisition(ICommand command);
    }
}
