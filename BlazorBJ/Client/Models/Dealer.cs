using System.Linq;
using System.Threading.Tasks;

namespace BlazorBJ.Client.Models
{
    public class Dealer : Person
    {
        public CardDeck Deck { get; set; } = new CardDeck();

        private Card DealCard() => Deck.DrawCard();

        public bool HasToHit => Score < 17;


        public async Task DealToSelfAsync(bool isVisible)
        {
            var card = DealCard();
            card.IsVisible = isVisible;
            await AddCardAsync(card);
        } 

        public async Task DealToPlayerAsync(Player player)
        {
            var card = DealCard();
            card.IsVisible = true;
            await player.AddCardAsync(card);
        } 

        public bool HasAceShowing => Cards.Count == 2 && VisibleScore == 11 && Cards.Any(x => !x.IsVisible);
    }
}