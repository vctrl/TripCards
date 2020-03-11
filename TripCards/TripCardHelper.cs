namespace TripCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// This class is for sort method
    /// </summary>
    public static class CardHelper
    {
        /// <summary>
        /// This method returns cards in the ready-to-trip order
        /// </summary>
        /// <param name="cards"> Initial collection of cards </param>
        /// <returns> Sorted collection of cards </returns>
        public static IEnumerable<TripCard> GetSortedCards(IEnumerable<TripCard> cards)
        {
            if (cards == null)
            {
                throw new ArgumentNullException("argument is null");
            }

            var dictFrom = cards.Where(c => c != null).GroupBy(c => c.From).ToDictionary(g => g.Key, g => g.First());
            var dictTo = cards.Where(c => c != null).GroupBy(c => c.To).ToDictionary(g => g.Key, g => g.First());
            var result = new List<TripCard>();

            var current = (from itemFrom in dictFrom where !dictTo.ContainsKey(itemFrom.Key) select itemFrom.Value)
                .FirstOrDefault();

            while (current != null)
            {
                result.Add(current);
                dictFrom.TryGetValue(current.To, out current);
            }

            return result;
        }
    }
}