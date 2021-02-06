namespace BlazorBJ.Client.Models
{
    public class Player : Person
    {
        public decimal Funds { get; set; } = 200M;
        
        public decimal Bet { get; set; }
        public decimal InsuranceBet { get; set; }
        public decimal Change { get; set; }

        public bool HasInsurance => InsuranceBet > 0M;
        public bool CanDoubleDown => Score > 8 && Score < 12 && Cards.Count == 2 && Funds >= Bet * 2;
        
        public void Collect()
        {
            Funds += Change;
        }
    }
}