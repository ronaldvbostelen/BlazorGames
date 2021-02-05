using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using BlazorBJ.Client.Game.States;
using BlazorBJ.Client.Game.States.Abstractions;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game
{
    public class BlackjackGame
    {
        public List<string> Log { get; } 
        public Player Player { get; private set; }
        public Dealer Dealer { get; private set; }
        public bool Started { get; set; }
        
        public IBjState BettingState { get; }
        public IBjState NotStartedState { get; }
        public IBjState DealingState { get; }
        public IBjState ShufflingState { get; }
        public IBjState PlayingState { get; }
        public IBjState BlackjackState { get; }
        public IBjState PayoutState { get; }
        public IBjState DealerState { get; }
        public IBjState EscortedOut { get; }

        public IBjState State { get; set; }
        
        public BlackjackGame(Dealer dealer, Player player)
        {
            Log = new List<string>();
            
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
            EscortedOut = new EscortedOutState(this);
        }

        public void LogMessage(string from, string msg) // TODO implement this in states
        {
            var logMsg = $"({Log.Count + 1}) {from}: [{msg}]";
            Debug.WriteLine(logMsg);
            Log.Add(logMsg);
        }

        public void MakeBet(decimal amount)
        {
            var bet = State.MakeBet(amount);
        }

        public void StartGame()
        {
            State = NotStartedState;
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

        public async Task PlayerDoubleDownsAsync()
        {
            var doubleDown = await State.DoublingDownAsync();
        }
        
        public void ShuffleCards()
        {
            var shuffled = State.ShuffleCards();
        }

        public void NewGame()
        {
            Started = false;
            State = NotStartedState;
            Dealer = new Dealer();
            Player = new Player();
        }
    }
}