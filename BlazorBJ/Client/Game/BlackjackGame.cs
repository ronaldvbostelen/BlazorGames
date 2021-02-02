using System.Threading.Tasks;
using BlazorBJ.Client.Game.States;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game
{
    public class BlackjackGame
    {
        public Player Player { get; }
        public Dealer Dealer { get; }
        public bool Blackjack { get; set; }
        
        public IBjState BettingState { get; }
        public IBjState NotStartedState { get; }
        public IBjState DealingState { get; }
        public IBjState ShufflingState { get; }
        public IBjState PlayingState { get; }
        public IBjState BlackjackState { get; }
        public IBjState PayoutState { get; }
        public IBjState DealerState { get; }
        public IBjState State { get; set; }
        
        public BlackjackGame(Dealer dealer, Player player)
        {
            Dealer = dealer;
            Player = player;
            
            BettingState = new BettingState(this);
            NotStartedState = new NotStartedState(this);
            DealingState = new DealingState(this);
            ShufflingState = new ShufflingState(this);
            PlayingState = new PlayingState(this);
            BlackjackState = new BlackjackState(this);
            PayoutState = new PayoutState(this);
            DealerState = new DealerState(this);
            
            State = ShufflingState;
        }

        public void MakeBet(decimal amount)
        {
            var bet = State.MakeBet(amount);
        }

        public void StartGame()
        {
            var start = State.Start();
        }

        public async Task InitialDealingAsync()
        {
            var initialDealing = await State.DealInitialCardsAsync();
        }

        public void Payout()
        {
            var payout = State.Pay();
        }


        public async Task<bool> HitPlayerAsync()
        {
            return await State.HitAsync();
        }

        public void StandPlayer()
        {
            var standPlayer = State.Stand();
        }

        public async Task DealersTurnAsync()
        {
            var flipCard = State.FlipCard();
            while (Dealer.HasToHit)
            {
                var hit = await State.HitAsync();
            }
        }

        public void PlayerTakesInsurance()
        {
            var insurance = State.TakeInsurance();
        }

        public void PlayerDoubleDowns()
        {
            var doubleDown = State.DoublingDown();
        }
        
        public void ShuffleCards()
        {
            var shuffled = State.ShuffleCards();
        }
    }
}