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
            _game.Blackjack = false;
            _game.State = _game.DealingState;
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

        public Task<bool> DoublingDown()
        {
            throw new System.NotImplementedException();
        }
    }
}