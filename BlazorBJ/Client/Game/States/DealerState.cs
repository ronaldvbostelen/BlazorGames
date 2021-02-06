using System.Linq;
using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;

namespace BlazorBJ.Client.Game.States
{
    public class DealerState : IBjState
    {
        private BlackjackGame _game;

        public DealerState(BlackjackGame game)
        {
            _game = game;
        }

        public bool MakeBet(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public bool Start()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DealInitialCardsAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool ShuffleCards()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> HitAsync()
        {
            if (_game.Dealer.Deck.Count < 1 || _game.Dealer.HasStood || _game.Dealer.IsBusted || !_game.Dealer.HasToHit)
            {
                return false;
            }
            
            await _game.Dealer.DealToSelfAsync(true);

            if (_game.Dealer.IsBusted || !_game.Dealer.HasToHit)
            {
                _game.State = _game.PayoutState;
            }

            return true;
        }

        public bool Stand()
        {
            throw new System.NotImplementedException();
        }

        public bool TakeInsurance()
        {
            throw new System.NotImplementedException();
        }

        public bool TakeNoInsurance()
        {
            throw new System.NotImplementedException();
        }

        public bool Pay()
        {
            throw new System.NotImplementedException();
        }

        public bool FlipCard()
        {
            if (_game.Dealer.Cards.All(x => x.IsVisible))
            {
                return false;
            }

            foreach (var card in _game.Dealer.Cards)
            {
                card.IsVisible = true;
            }

            if (_game.Dealer.Score > 16)
            {
                _game.State = _game.PayoutState;
            }

            return true;
        }

        public Task<bool> DoublingDownAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}