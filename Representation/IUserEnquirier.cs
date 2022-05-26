using System;

namespace dk.itu.game.msc.cgol.Representation
{
    public interface IUserEnquirer
    {
        Guid? SelectCard(int playerIndex, string collection, string[]? requiredTags, bool required);
        bool AskPlayer(int playerIndex, string message);
        void SendConclusion(string message);
    }
}
