namespace TripCards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    
    /// <summary>
    /// Tests of cards sorting method
    /// </summary>
    public class Tests
    {
        /// <summary>
        /// Ignore nulls in input collection
        /// </summary>
        [Test]
        public void NullsInList()
        {
            Assert.IsEmpty(CardHelper.GetSortedCards(new List<TripCard> { null }));
        }
        
        /// <summary>
        /// Method returns exception if argument is null
        /// </summary>
        [Test]
        public void EmptyListIfArgumentIsNull()
        {
            Assert.That(() => CardHelper.GetSortedCards(null), 
                Throws.Exception.TypeOf<ArgumentNullException>());
        }

        /// <summary>
        /// Method returns no duplicate values
        /// </summary>
        [Test]
        public void ResultWithoutDuplicates()
        {
            var cards = new List<TripCard>
            {
                new TripCard("1", "2"),
                new TripCard("0", "1"),
                new TripCard("1", "2"),
                new TripCard("0", "1"),
                new TripCard("1", "2")
            };

            var fact = CardHelper.GetSortedCards(cards);
            var expected = new List<TripCard>
            {
                new TripCard("0", "1"),
                new TripCard("1", "2")
            };

            CollectionAssert.AreEqual(fact, expected);
        }

        /// <summary>
        /// Method returns empty list if there's a cycle
        /// </summary>
        [Test]
        public void EmptyListIfCycle()
        {
            var cards = new List<TripCard>
            {
                new TripCard("1", "2"),
                new TripCard("2", "3"),
                new TripCard("3", "4"),
                new TripCard("4", "1")
            };

            var fact = CardHelper.GetSortedCards(cards);
            Assert.IsEmpty(fact);
        }

        /// <summary>
        /// Method returns result including only linked cards from one set
        /// </summary>
        [Test]
        public void ResultContainsOnlyLinkedCards()
        {
            var cards = new List<TripCard>
            {
                new TripCard("1", "2"),
                new TripCard("2", "3"),
                new TripCard("5", "6"),
                new TripCard("3", "4")
            };

            var fact = CardHelper.GetSortedCards(cards);
            var expected3 = new List<TripCard>
            {
                new TripCard("1", "2"),
                new TripCard("2", "3"),
                new TripCard("3", "4")
            };

            CollectionAssert.AreEqual(fact, expected3);
        }

        /// <summary>
        /// Test with shuffle
        /// </summary>
        [Test]
        public void ShuffleTest()
        {
            var cards = new List<TripCard>();
            for (var i = 0; i < 101; i++)
            {
                cards.Add(new TripCard(i.ToString(), (i + 1).ToString()));
            }

            var rnd = new Random();
            var cardsShuffled = cards.OrderBy(item => rnd.Next());
            var fact = CardHelper.GetSortedCards(cardsShuffled);
            CollectionAssert.AreEqual(fact, cards);
        }
    }
}