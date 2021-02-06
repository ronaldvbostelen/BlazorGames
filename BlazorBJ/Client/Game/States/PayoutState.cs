using System;
using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

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
        
        public bool Pay()
        {
            if (_game.Player.HasNaturalBlackjack || _game.Dealer.HasNaturalBlackjack)
            {
                _game.Player.Change = RolledBlackjack();
            }
            else if (PlayerLost())
            {
                _game.Player.Change = -(_game.Player.Bet + _game.Player.InsuranceBet);
            }
            else if (PlayerWon())
            {
                _game.Player.Change = _game.Player.Bet - _game.Player.InsuranceBet;
            }
            else
            {
                _game.Player.Change = -_game.Player.InsuranceBet;
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

        private decimal RolledBlackjack()
        {
            if (!_game.Player.HasNaturalBlackjack && !_game.Dealer.HasNaturalBlackjack ||
                _game.Player.HasNaturalBlackjack && _game.Dealer.HasNaturalBlackjack)
            {
                return 0M;
            }

            if (_game.Dealer.HasNaturalBlackjack && !_game.Player.HasNaturalBlackjack)
            {
                return -_game.Player.Bet + (2 * _game.Player.InsuranceBet);
            }

            return _game.Player.Bet * 1.5M;
        }

        private bool PlayerLost()
        {
            return _game.Player.IsBusted || (_game.Player.Score < _game.Dealer.Score && !_game.Dealer.IsBusted);
        }

        private bool PlayerWon()
        {
            return (!_game.Player.IsBusted && _game.Player.Score > _game.Dealer.Score) ||_game.Dealer.IsBusted;
        }
    }
}