using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;

namespace BlazorBJ.Client.Game.States
{
    public class PlayingState : IBjState
    {
        private BlackjackGame _game;

        public PlayingState(BlackjackGame game)
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
            if (_game.Player.IsBusted || _game.Player.HasStood || _game.Dealer.Deck.Count < 1)
            {
                return false;
            }

            await _game.Dealer.DealToPlayerAsync(_game.Player);

            if (_game.Player.IsBusted)
            {
                _game.State = _game.PayoutState;
            }

            return true;
        }

        public bool Stand()
        {
            if (_game.Player.IsBusted || _game.Player.HasStood)
            {
                return false;
            }

            _game.Player.HasStood = true;
            _game.State = _game.DealerState;
            
            return true;
        }

        public bool TakeInsurance()
        {
            if (!_game.Dealer.HasAceShowing)
            {
                return false;
            }

            _game.Player.InsuranceBet = _game.Player.Bet / 2;

            if (_game.Dealer.HasNaturalBlackjack)
            {
                if (_game.Player.HasInsurance)
                {
                    _game.Player.Change += (2 * _game.Player.InsuranceBet);
                }

                _game.State = _game.PayoutState;
            }
            else
            {
                _game.Player.Change -= _game.Player.InsuranceBet;
            }

            return true;
        }

        public void Collect()
        {
            throw new System.NotImplementedException();
        }

        public bool Pay()
        {
            throw new System.NotImplementedException();
        }

        public bool FlipCard()
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DoublingDown()
        {
            if (_game.Player.Cards.Count != 2 || (_game.Player.Score > 8 && _game.Player.Score < 12) || _game.Player.Funds < _game.Player.Bet*2)
            {
                return false;
            }

            _game.Player.Bet *= 2;
            await HitAsync();
            Stand();

            _game.State = _game.DealerState;
            
            return true;
        }
    }
}