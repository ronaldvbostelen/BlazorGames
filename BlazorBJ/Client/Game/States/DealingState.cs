using System;
using System.Linq;
using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game.States
{
    public class DealingState : IBjState
    {
        private BlackjackGame _game;

        public DealingState(BlackjackGame game)
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

        public async Task<bool> DealInitialCardsAsync()
        {
            if (_game.Dealer.Deck.Count < 4)
            {
                return false;
            }
            
            await _game.Dealer.DealToPlayerAsync(_game.Player);
            await _game.Dealer.DealToSelfAsync(true);
            await _game.Dealer.DealToPlayerAsync(_game.Player);
            await _game.Dealer.DealToSelfAsync(false);
            
            if (_game.Player.HasNaturalBlackjack || _game.Dealer.HasNaturalBlackjack)
            {
                _game.Blackjack = true;
                _game.State = _game.PayoutState;
            }
            else
            {
                _game.State = _game.PlayingState;
            }

            return true;
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
            throw new NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public bool FlipCard()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DoublingDown()
        {
            throw new NotImplementedException();
        }
    }
}