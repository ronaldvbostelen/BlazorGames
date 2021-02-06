using System.Threading.Tasks;
using BlazorBJ.Client.Models;

namespace BlazorBJ.Client.Game.States.Abstractions
{
    public interface IBjState
    {
        bool MakeBet(decimal amount);
        bool Start();
        Task<bool> DealInitialCardsAsync();
        bool ShuffleCards();
        Task<bool> HitAsync();
        bool Stand();
        bool TakeInsurance();
        bool TakeNoInsurance();
        bool Pay();
        bool FlipCard();
        Task<bool> DoublingDownAsync();
    }
}