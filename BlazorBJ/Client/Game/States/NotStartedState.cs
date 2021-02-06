using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game.States
{
    public class NotStartedState : IBjState
    {
        private BlackjackGame _game;

        public NotStartedState(BlackjackGame game)
        {
            _game = game;
        }
        
        public bool MakeBet(decimal amount)
        {
            throw new System.NotImplementedException();
        }

        public bool Start()
        {
            _game.Player.ClearHand();
            _game.Dealer.ClearHand();
            _game.Player.HasStood = false;
            _game.Started = true;
            _game.Player.Change = _game.Player.Bet = _game.Player.InsuranceBet = 0M;
            
            _game.State = _game.ShufflingState;
            return true;
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
            throw new System.NotImplementedException();
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