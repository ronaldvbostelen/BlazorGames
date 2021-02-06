using System.Threading.Tasks;
using BlazorBJ.Client.Game.States.Abstractions;

namespace BlazorBJ.Client.Game.States
{
    public class BlackjackState : IBjState
    {
        private BlackjackGame _game;

        public BlackjackState(BlackjackGame game)
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