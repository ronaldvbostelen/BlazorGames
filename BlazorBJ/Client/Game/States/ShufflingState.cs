using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game.States
{
    public class ShufflingState : IBjState
    {
        private BlackjackGame _game;

        public ShufflingState(BlackjackGame game)
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
            _game.Dealer.Deck = new CardDeck();
            _game.State = _game.BettingState;
            return true;
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