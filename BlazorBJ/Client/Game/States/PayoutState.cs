using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;

namespace BlazorBJ.Client.Game.States
{
    public class PayoutState : IBjState
    {
        private BlackjackGame _game;

        public PayoutState(BlackjackGame game)
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

        public Task<bool> HitAsync()
        {
            throw new System.NotImplementedException();
        }

        public bool Stand()
        {
            throw new System.NotImplementedException();
        }

        public bool TakeInsurance()
        {
            throw new System.NotImplementedException();
        }

        public void Collect()
        {
            throw new System.NotImplementedException();
        }

        public bool Pay()
        {
            if (_game.Player.IsBusted || (_game.Player.Score < _game.Dealer.Score && !_game.Dealer.IsBusted))
            {
                _game.Player.Change = -_game.Player.Bet;
                
            }
            else if (_game.Player.HasNaturalBlackjack || _game.Dealer.HasNaturalBlackjack)
            {
                if (_game.Player.HasNaturalBlackjack && !_game.Dealer.HasNaturalBlackjack)
                {
                    _game.Player.Change = 1.5M * _game.Player.Bet;
                }   
                else if (_game.Dealer.HasNaturalBlackjack)
                {
                    _game.Player.Change = -_game.Player.Bet;
                }
                else
                {
                    _game.Player.Change = _game.Player.Bet;
                }
            }
            else if (_game.Player.Score > _game.Dealer.Score || _game.Dealer.IsBusted)
            {
                _game.Player.Change = _game.Player.Bet;
            }
            else
            {
                // PUSH (equal score)
            }
            
            _game.Dealer.Cards.ForEach(x => x.IsVisible = true);
            _game.Player.Collect();
            
            return true;
        }

        public bool FlipCard()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DoublingDownAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}