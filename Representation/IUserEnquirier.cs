using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public interface IUserEnquirer
    {
        Guid? SelectCard(int playerIndex, string collection, string[]? requiredTags, bool required);
        bool AskPlayer(int playerIndex, string message);
    }
}
