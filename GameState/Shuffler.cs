using dk.itu.game.msc.cgol.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class Shuffler
    {
        Random random;

        public Shuffler(int seed)
        {
            random = new Random(seed);
        }

        public List<T> Shuffle<T>(List<T> list)
        {
            var size = list.Count();
            var shuffledList =
                list.
                    Select(x => new { Number = random.Next(), Item = x }).
                    OrderBy(x => x.Number).
                    Select(x => x.Item).
                    Take(size); // Assume first @size items is fine

            return shuffledList.ToList();
        }

        public Dictionary<Guid, ICard> Shuffle(Dictionary<Guid, ICard> dictionary)
        {
            var guids = GenerateGuids(dictionary.Count).ToArray();
            var index = 0;
            Dictionary<Guid, ICard> newDictionary = new Dictionary<Guid, ICard>();
            foreach (var card in dictionary.Values)
            {
                card.Instance = guids[index];
                newDictionary.Add(card.Instance, card);
            }
            return newDictionary;
        }

        private IEnumerable<Guid> GenerateGuids(int amount)
        {
            var guid = new byte[16];
            for (int i = 0; i < amount; i++)
            {
                random.NextBytes(guid);
                yield return new Guid(guid);
            }
        }
    }
}
