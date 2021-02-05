using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBJ.Client.Models
{
    public class Person
    {
        public List<Card> Cards { get; set; } = new List<Card>();

        public int Score => ScoreCalculation();
        public int VisibleScore => ScoreCalculation(true);
        public bool HasStood { get; set; }
        
        private int ScoreCalculation(bool onlyVisible = false)
        {
            var cards = Cards;

            if (onlyVisible)
            {
                cards = Cards.Where(x => x.IsVisible).ToList();
            }

            var totalScore = cards.Sum(x => x.Score);
            if (totalScore <= 21) return totalScore;

            var hasAces = cards.Any(x => x.IsAce);
            if (!hasAces) return totalScore;

            var acesCount = cards.Count(x => x.IsAce);
            var acesScore = totalScore;

            while (acesCount > 0)
            {
                acesCount--;
                acesScore -= 10;
                if (acesScore <= 21) return acesScore;
            }

            return totalScore;
        }

        public bool HasNaturalBlackjack => Cards.Count == 2 && Score == 21;
        public bool IsBusted => Score > 21;

        public string ScoreDisplay
        {
            get
            {
                if (HasNaturalBlackjack && Cards.All(x => x.IsVisible))
                {
                    return "Blackjack!";
                }

                var score = VisibleScore;
                if (score > 21)
                {
                    return "Busted!";
                }

                return score.ToString();
            }
        }

        public async Task AddCardAsync(Card card)
        {
            Cards.Add(card);
            await Task.Delay(300);
        }

        public void ClearHand()
        {
            Cards.Clear();
        }
    }
}